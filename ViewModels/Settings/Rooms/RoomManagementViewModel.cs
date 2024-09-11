using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHEndevour.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using SHEndevour.Views;
using MessageBox = System.Windows.MessageBox;
using SHEndevour.Utilities;
using SHEndevour.Views.Settings.Rooms.Dialogs;
using DevExpress.XtraRichEdit.Import.Doc;
using System.Diagnostics;

namespace SHEndevour.ViewModels.Settings.Rooms
{
    public partial class RoomManagementViewModel : ObservableObject
    {
        // Propiedades enlazadas en la vista
        [ObservableProperty]
        private ObservableCollection<RoomModel> rooms;

        [ObservableProperty]
        private ObservableCollection<RoomModel> filteredRooms;

        [ObservableProperty]
        private RoomModel selectedRoom;

        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private bool isPopupOpen;

        // Comandos
        public ICommand AddRoomCommand { get; }
        public ICommand ViewRoomCommand { get; }
        public ICommand DeleteRoomCommand { get; }
        public ICommand SearchCommand { get; }

        public RoomManagementViewModel()
        {
            Rooms = new ObservableCollection<RoomModel>();
            FilteredRooms = new ObservableCollection<RoomModel>();
            IsPopupOpen = false;

            // Cargar las habitaciones desde la base de datos
            LoadRooms();

            // Inicializar los comandos
            AddRoomCommand = new RelayCommand(AddRoom);
            ViewRoomCommand = new RelayCommand(ViewRoom);
            DeleteRoomCommand = new RelayCommand(DeleteRoom);
            SearchCommand = new RelayCommand(SearchRoom);
        }

        private void LoadRooms()
        {
            using (var dbContext = new AppDbContext())
            {
                var roomsFromDb = dbContext.RoomTable
                                           .Include(r => r.RoomType)
                                           .ToList();

                Rooms.Clear();

                foreach (var room in roomsFromDb)
                {
                    Rooms.Add(room);
                }

                FilterRooms(); // Filtra las habitaciones inmediatamente después de cargarlas
            }
        }

        #region AddRoomRegion
        private void AddRoom()
        {
            var addRoomDialog = new AddEditRoomDialog();

            if (addRoomDialog.ShowDialog() == true)
            {
                var newRoom = addRoomDialog.Room;

                using (var dbContext = new AppDbContext())
                {
                    dbContext.RoomTable.Add(newRoom);
                    dbContext.SaveChanges();
                }

                LoadRooms();
                MessageBox.Show("Habitación añadida con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

        #region ViewRoomRegion
        private void ViewRoom()
        {
            var selectedRoom = Rooms.FirstOrDefault(rt => rt.IsSelected);
            Debug.WriteLine($"RoomTypeIdVIEWMODEL Entrando al ViewRoom: {selectedRoom.RoomTypeId}");

            if (selectedRoom != null)
            {
                var editRoomDialog = new AddEditRoomDialog(selectedRoom);
                Debug.WriteLine($"RoomTypeIdVIEWMODEL si se Selecciono un Room: {selectedRoom.RoomTypeId}");

                if (editRoomDialog.ShowDialog() == true)
                {
                    var updatedRoom = editRoomDialog.Room;
                    Debug.WriteLine($"RoomTypeIdVIEWMODEL si el Dialogo de Update es Verdadero: {updatedRoom.RoomTypeId}");

                    using (var dbContext = new AppDbContext())
                    {
                        // Busca en la tabla `RoomTypeTable` del contexto de base de datos (`dbContext`)
                        // la entidad `RoomTypeModel` que tiene el mismo `Id` que la propiedad `RoomTypeId`
                        // de la habitación actualizada (`updatedRoom`), y luego asigna esa entidad `RoomTypeModel`
                        // encontrada a la propiedad `RoomType` de la habitación (`updatedRoom`).
                        // Esto asegura que la propiedad de navegación `RoomType` esté correctamente
                        // relacionada con la entidad `RoomTypeModel` correspondiente antes de guardar
                        // los cambios en la base de datos.

                        // Asociar la entidad RoomType  
                        updatedRoom.RoomType = dbContext.RoomTypeTable.Find(updatedRoom.RoomTypeId);

                        // Actualizar la habitación en la base de datos
                        dbContext.RoomTable.Update(updatedRoom);
                        dbContext.SaveChanges();
                    }

                    LoadRooms();
                    MessageBox.Show("Habitación actualizada con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                Debug.WriteLine($"RoomTypeIdVIEWMODEL Despues del Dialogo de Confirmacion: {selectedRoom.RoomTypeId}");
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una habitación para ver.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

        #region DeleteRoomRegion
        private void DeleteRoom()
        {
            var selectedRooms = Rooms.Where(r => r.IsSelected).ToList();

            if (selectedRooms.Any())
            {
                var result = MessageBox.Show($"¿Estás seguro de que deseas eliminar {selectedRooms.Count} habitación(es)?",
                                             "Confirmar eliminación",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using (var dbContext = new AppDbContext())
                    {
                        foreach (var room in selectedRooms)
                        {
                            dbContext.RoomTable.Remove(room);
                        }
                        dbContext.SaveChanges();
                    }

                    LoadRooms();
                    MessageBox.Show("Habitación(es) eliminada(s) con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione al menos una habitación para eliminar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region SearchRoomRegion
        private void SearchRoom()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredRooms.Clear();
                IsPopupOpen = false;
                return;
            }

            var filteredRoomsList = Rooms
                .Where(r => r.RoomKey.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                            r.RoomStatus.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            FilteredRooms = new ObservableCollection<RoomModel>(filteredRoomsList);
            IsPopupOpen = FilteredRooms.Any(); // Mostrar el Popup solo si hay resultados

            SelectedRoom = null; // Asegurarse de que no haya una habitación seleccionada accidentalmente al escribir
        }

        private void FilterRooms()
        {
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                SearchRoom();
            }
            else
            {
                FilteredRooms.Clear();
                foreach (var room in Rooms)
                {
                    FilteredRooms.Add(room);
                }
            }
        }

        partial void OnSearchTextChanged(string value)
        {
            SelectedRoom = null;
            SearchRoom();
        }

        partial void OnSelectedRoomChanged(RoomModel room)
        {
            if (room != null)
            {
                var editRoomDialog = new AddEditRoomDialog(room);

                if (editRoomDialog.ShowDialog() == true)
                {
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.RoomTable.Update(room);
                        dbContext.SaveChanges();
                    }

                    LoadRooms();
                    MessageBox.Show("Habitación actualizada con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
                
                IsPopupOpen = false;

            }

            
        }
        #endregion
    }
}
