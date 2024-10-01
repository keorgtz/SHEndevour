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
        private RoomTypeModel selectedRoomType;

        // Comandos
        public ICommand AddRoomTypeCommand { get; }
        public ICommand ViewRoomTypeCommand { get; }
        public ICommand DeleteRoomTypeCommand { get; }


        public RoomTypeManagementViewModel()
        {
            RoomTypes = new ObservableCollection<RoomTypeModel>();


            // Cargar los tipos de habitación desde la base de datos
            LoadRoomTypes();

            // Inicializa los comandos
            AddRoomTypeCommand = new RelayCommand(AddRoomType);
            ViewRoomTypeCommand = new RelayCommand(ViewRoomType, CanEditOrDelete);
            DeleteRoomTypeCommand = new RelayCommand(DeleteRoomType, CanEditOrDelete);

        }

        private void LoadRoomTypes()
        {
            using (var dbContext = new AppDbContext())
            {
                var roomTypesFromDb = dbContext.RoomTypeTable
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
                    dbContext.RoomTypeTable.Add(newRoomType);
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
            //var selectedRoomType = RoomTypes.FirstOrDefault(rt => rt.IsSelected);

            if (SelectedRoomType != null)
            {
                var editRoomTypeDialog = new AddEditRoomTypeDialog(SelectedRoomType);

                if (editRoomTypeDialog.ShowDialog() == true)
                {
                    var updateRoomT = editRoomTypeDialog.RoomTypeD;

                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.RoomTypeTable.Update(updateRoomT);
                        dbContext.SaveChanges();
                    }


                    LoadRoomTypes();
                    MessageBox.Show("Tipo de habitación actualizado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    LoadRoomTypes();
                    MessageBox.Show("Operacion Cancelada", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Information);
                }

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
            if (SelectedRoomType != null)
            {
                using (var dbContext = new AppDbContext())
                {
                    // Verificar si existen habitaciones asociadas a este RoomType
                    bool hasAssociatedRooms = dbContext.RoomTable.Any(room => room.RoomTypeId == SelectedRoomType.Id);

                    if (hasAssociatedRooms)
                    {
                        MessageBox.Show("No se puede eliminar este tipo de habitación porque existen habitaciones asociadas.",
                                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var result = MessageBox.Show($"¿Estás seguro de que deseas eliminar el tipo de habitación '{SelectedRoomType.RoomTypeKey}'?",
                                                 "Confirmar eliminación",
                                                 MessageBoxButton.YesNo,
                                                 MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        dbContext.RoomTypeTable.Remove(SelectedRoomType);
                        dbContext.SaveChanges();

                        LoadRoomTypes();
                        MessageBox.Show("Tipo de habitación eliminado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un tipo de habitación para eliminar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }



        #endregion

        private bool CanEditOrDelete()
        {
            return SelectedRoomType != null;
        }

        partial void OnSelectedRoomTypeChanged(RoomTypeModel value)
        {
            (ViewRoomTypeCommand as RelayCommand)?.NotifyCanExecuteChanged();
            (DeleteRoomTypeCommand as RelayCommand)?.NotifyCanExecuteChanged();
        }
       
    }
}
