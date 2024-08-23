using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHEndevour.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using SHEndevour.Views.Settings.Rooms.Dialogs;
using SHEndevour.Utilities;
using MessageBox = System.Windows.MessageBox;
using SHEndevour.Views.Settings.Rooms;

namespace SHEndevour.ViewModels.Settings.Rooms
{
    public partial class RoomTypeManagementViewModel : ObservableObject
    {
        // Propiedades que enlazarás en la vista
        [ObservableProperty]
        private ObservableCollection<RoomTypeModel> roomTypes;

        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private ObservableCollection<RoomTypeModel> filteredRoomTypes;

        [ObservableProperty]
        private bool isPopupOpen; // Para manejar la visibilidad del popup

        [ObservableProperty]
        private RoomTypeModel selectedRoomType;

        // Comandos
        public ICommand AddRoomTypeCommand { get; }
        public ICommand ViewRoomTypeCommand { get; }
        public ICommand DeleteRoomTypeCommand { get; }
        public ICommand SearchCommand { get; }

        public RoomTypeManagementViewModel()
        {
            RoomTypes = new ObservableCollection<RoomTypeModel>();
            FilteredRoomTypes = new ObservableCollection<RoomTypeModel>();
            IsPopupOpen = false;

            // Cargar los tipos de habitación desde la base de datos
            LoadRoomTypes();

            // Inicializa los comandos
            AddRoomTypeCommand = new RelayCommand(AddRoomType);
            ViewRoomTypeCommand = new RelayCommand(ViewRoomType);
            DeleteRoomTypeCommand = new RelayCommand(DeleteRoomType);
            SearchCommand = new RelayCommand(SearchRoomType);
        }

        private void LoadRoomTypes()
        {
            using (var dbContext = new AppDbContext())
            {
                var roomTypesFromDb = dbContext.RoomType
                                               .Include(rt => rt.Rooms) // Incluir las habitaciones asociadas si es necesario
                                               .ToList();

                RoomTypes.Clear(); // Limpiar la colección actual

                foreach (var roomType in roomTypesFromDb)
                {
                    RoomTypes.Add(roomType);
                    
                }
            }
        }

        #region AddRoomTypeRegion
        private void AddRoomType()
        {
            // Abrir el diálogo de agregar tipo de habitación
            var addRoomTypeDialog = new AddEditRoomTypeDialog();

            if (addRoomTypeDialog.ShowDialog() == true)
            {
                var newRoomType = addRoomTypeDialog.RoomTypeD;

                using (var dbContext = new AppDbContext())
                {
                    dbContext.RoomType.Add(newRoomType);
                    dbContext.SaveChanges();
                }

                LoadRoomTypes();
                MessageBox.Show("Tipo de habitación añadido con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion

        #region ViewRoomTypeRegion
        private void ViewRoomType()
        {
            var selectedRoomType = RoomTypes.FirstOrDefault(rt => rt.IsSelected);

            if (selectedRoomType != null)
            {
                var editRoomTypeDialog = new AddEditRoomTypeDialog(selectedRoomType);

                if (editRoomTypeDialog.ShowDialog() == true)
                {
                    var updateRoomT = editRoomTypeDialog.RoomTypeD;

                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.RoomType.Update(updateRoomT);
                        dbContext.SaveChanges();
                    }


                    LoadRoomTypes();
                    MessageBox.Show("Tipo de habitación actualizado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                selectedRoomType.IsSelected = false;
                SelectedRoomType = null;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un tipo de habitación para ver.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region DeleteRoomTypeRegion
        private void DeleteRoomType()
        {
            var selectedRoomTypes = RoomTypes.Where(rt => rt.IsSelected).ToList();

            if (selectedRoomTypes.Any())
            {
                var result = MessageBox.Show($"¿Estás seguro de que deseas eliminar {selectedRoomTypes.Count} tipo(s) de habitación?",
                                             "Confirmar eliminación",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using (var dbContext = new AppDbContext())
                    {
                        foreach (var roomType in selectedRoomTypes)
                        {
                            dbContext.RoomType.Remove(roomType);
                        }
                        dbContext.SaveChanges();
                    }

                    LoadRoomTypes();
                    MessageBox.Show("Tipo(s) de habitación eliminado(s) con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione al menos un tipo de habitación para eliminar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region SearchRoomTypeRegion
        private void SearchRoomType()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredRoomTypes.Clear();
                IsPopupOpen = false;
                return;
            }

            var filteredRoomTypesList = RoomTypes
                .Where(rt => rt.RoomTypeKey.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                             rt.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            FilteredRoomTypes = new ObservableCollection<RoomTypeModel>(filteredRoomTypesList);
            IsPopupOpen = FilteredRoomTypes.Any(); // Mostrar el Popup solo si hay resultados

            // Asegurarse de que no haya un tipo de habitación seleccionado accidentalmente al escribir
            SelectedRoomType = null;
        }

        partial void OnSearchTextChanged(string value)
        {
            SelectedRoomType = null;
            SearchRoomType();
        }

        partial void OnSelectedRoomTypeChanged(RoomTypeModel roomType)
        {
            if (roomType != null)
            {
                var editRoomTypeDialog = new AddEditRoomTypeDialog(roomType);

                if (editRoomTypeDialog.ShowDialog() == true)
                {
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.RoomType.Update(roomType);
                        SelectedRoomType.IsSelected = false;
                        dbContext.SaveChanges();
                    }

                    SelectedRoomType.IsSelected = false;
                    LoadRoomTypes();
                    MessageBox.Show("Tipo de habitación actualizado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
                SelectedRoomType.IsSelected = false;
                SelectedRoomType = null;
                IsPopupOpen = false;
            }
        }
        #endregion
    }
}
