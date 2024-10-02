using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHEndevour.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using MessageBox = System.Windows.MessageBox;
using SHEndevour.Utilities;
using SHEndevour.Views.Settings.Rooms.Dialogs;

namespace SHEndevour.ViewModels.Settings.Rooms
{
    public partial class RoomManagementViewModel : ObservableObject
    {
        // Propiedades enlazadas en la vista
        [ObservableProperty]
        private ObservableCollection<RoomModel> rooms;

        [ObservableProperty]
        private ObservableCollection<RoomModel> notblockeds; 

        [ObservableProperty]
        private RoomModel selectedRoom;

        // Comandos
        public ICommand AddRoomCommand { get; }
        public ICommand ViewRoomCommand { get; }
        public ICommand DeleteRoomCommand { get; }

        public RoomManagementViewModel()
        {
            Rooms = new ObservableCollection<RoomModel>();
            Notblockeds = new ObservableCollection<RoomModel>();

            // Cargar las habitaciones desde la base de datos
            LoadRooms();
            LoadAvailableRooms();

            // Inicializar los comandos
            AddRoomCommand = new RelayCommand(AddRoom);
            ViewRoomCommand = new RelayCommand(ViewRoom, CanEditOrDelete);
            DeleteRoomCommand = new RelayCommand(DeleteRoom, CanEditOrDelete);
        }


        //Cargar las Habitaciones (Todas y las No Bloqueadas)
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
            }
        }

        // Método que carga solo las habitaciones cuyo RoomStatus no esté en "Bloqueado" o "Mantenimiento"
        private void LoadAvailableRooms()
        {
            using (var dbContext = new AppDbContext())
            {
                // Filtrar habitaciones que no estén en los estados Bloqueado o Mantenimiento
                var availableRoomsFromDb = dbContext.RoomTable
                                                    .Include(r => r.RoomType)
                                                    .Where(r => r.RoomStatus != RoomStatus.Bloqueado &&
                                                                r.RoomStatus != RoomStatus.Mantenimiento)
                                                    .ToList();

                Notblockeds.Clear();

                foreach (var nblock in availableRoomsFromDb)
                {
                    Notblockeds.Add(nblock);
                }
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

        #region ViewRoomRegion
        private void ViewRoom()
        {
            if (SelectedRoom != null)
            {
                var editRoomDialog = new AddEditRoomDialog(SelectedRoom);

                if (editRoomDialog.ShowDialog() == true)
                {
                    var updatedRoom = editRoomDialog.Room;

                    using (var dbContext = new AppDbContext())
                    {
                        // Asociar la entidad RoomType  
                        updatedRoom.RoomType = dbContext.RoomTypeTable.Find(updatedRoom.RoomTypeId);

                        // Actualizar la habitación en la base de datos
                        dbContext.RoomTable.Update(updatedRoom);
                        dbContext.SaveChanges();
                    }

                    LoadRooms();
                    MessageBox.Show("Habitación actualizada con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        #endregion

        #region DeleteRoomRegion
        private void DeleteRoom()
        {
            if (SelectedRoom != null)
            {
                // Verificar si el RoomStatus es VacioLimpio o VacioSucio
                if (SelectedRoom.RoomStatus == RoomStatus.VacioLimpio || SelectedRoom.RoomStatus == RoomStatus.VacioSucio)
                {
                    // Confirmar eliminación
                    if (MessageBox.Show("¿Estás seguro de que deseas eliminar esta habitación?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        using (var dbContext = new AppDbContext())
                        {
                            dbContext.RoomTable.Remove(SelectedRoom);
                            dbContext.SaveChanges();
                        }

                        Rooms.Remove(SelectedRoom);
                        MessageBox.Show("Habitación eliminada con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    // Mostrar un mensaje de error si el estado no es VacioLimpio o VacioSucio
                    MessageBox.Show($"No se puede Eliminar Esta Habitacion \nSu Estado esta en {SelectedRoom.RoomStatus}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #endregion

        private bool CanEditOrDelete()
        {
            return SelectedRoom != null;
        }

        partial void OnSelectedRoomChanged(RoomModel value)
        {
            (ViewRoomCommand as RelayCommand)?.NotifyCanExecuteChanged();
            (DeleteRoomCommand as RelayCommand)?.NotifyCanExecuteChanged();
        }
    }
}
