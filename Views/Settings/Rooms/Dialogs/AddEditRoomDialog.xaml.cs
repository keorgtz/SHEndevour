using SHEndevour.Models;
using SHEndevour.Utilities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using MessageBox = System.Windows.MessageBox;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ComboBox = System.Windows.Controls.ComboBox;
using Microsoft.VisualBasic.ApplicationServices;

namespace SHEndevour.Views.Settings.Rooms.Dialogs
{
    public partial class AddEditRoomDialog : Window
    {
        public RoomModel Room { get; private set; }

        public AddEditRoomDialog(RoomModel? room = null)
        {
            InitializeComponent();
            LoadRoomTypes();
            LoadRoomStatuses();
            LoadHousekeeperStatuses();

            if (room != null)
            {
                Room = room;
                PopulateFields();
                Title = "Editar Habitación";
                AddEditSubtitle.Text = "Edición de Habitación";
                Debug.WriteLine($"RoomTypeIdDIALOG antes de actualizar: {Room.RoomTypeId}");
                //room.IsSelected = false;
            }
            else
            {
                Room = new RoomModel();
                Title = "Añadir Habitación";
                AddEditSubtitle.Text = "Agregar una Nueva Habitación";
            }



            DataContext = Room;
            Room.IsSelected = false;
            ValidateFields();
        }

        private void LoadRoomTypes()
        {
            using (var context = new AppDbContext())
            {
                var roomTypes = context.RoomTypeTable.ToList();
                RoomTypComboBox.ItemsSource = roomTypes;
                RoomTypComboBox.DisplayMemberPath = "Description";
                RoomTypComboBox.SelectedValuePath = "Id";

            }
        }


        private void LoadRoomStatuses()
        {
            RoomStatusComboBox.ItemsSource = Enum.GetValues(typeof(RoomStatus)).Cast<RoomStatus>();
        }

        private void LoadHousekeeperStatuses()
        {
            HouseKeeperComboBox.ItemsSource = Enum.GetValues(typeof(HousekeeperStatus)).Cast<HousekeeperStatus>();
        }

        private void PopulateFields()
        {
            RoomKeyTextBox.Text = Room.RoomKey;
            RoomTypComboBox.SelectedValue = Room.RoomTypeId;
            RoomStatusComboBox.SelectedItem = Room.RoomStatus;
            HouseKeeperComboBox.SelectedItem = Room.HousekeeperStatus;
        }

        private void OnAcceptClick(object sender, RoutedEventArgs e)
        {
            if (RoomKeyTextBox.Text.Length > 10)
            {
                MessageBox.Show("La clave de la habitación no puede tener más de 10 caracteres.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (RoomTypComboBox.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de habitación.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Room.RoomKey != RoomKeyTextBox.Text && IsRoomKeyDuplicate(RoomKeyTextBox.Text))
            {
                MessageBox.Show("La clave de la habitación ya existe.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Debug.WriteLine($"RoomTypeIdDIALOG antes de actualizar: {Room.RoomTypeId}");

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            if (Room.RoomKey != RoomKeyTextBox.Text)
            {
                Room.RoomKey = RoomKeyTextBox.Text; // Almacenar el teléfono como cadena
            }

            if (Room.RoomTypeId != (int)RoomTypComboBox.SelectedValue)
            {
                Room.RoomTypeId = (int)RoomTypComboBox.SelectedValue; // Guarda el Id del rol seleccionado
            }

            if (Room.RoomStatus != (RoomStatus)RoomStatusComboBox.SelectedItem)
            {
                Room.RoomStatus = (RoomStatus)RoomStatusComboBox.SelectedItem; // Guarda el Id del rol seleccionado
            }

            if (Room.HousekeeperStatus != (HousekeeperStatus)HouseKeeperComboBox.SelectedItem)
            {
                Room.HousekeeperStatus = (HousekeeperStatus)HouseKeeperComboBox.SelectedItem; // Guarda el Id del rol seleccionado
            }

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // Actualizar los valores del modelo
            //Room.RoomKey = RoomKeyTextBox.Text;
            //RoomTypComboBox.GetBindingExpression(ComboBox.SelectedValueProperty)?.UpdateSource();
            //Room.RoomTypeId = (int?)RoomTypComboBox.SelectedValue ?? 0; // Asegúrate de que RoomTypeId esté asignado correctamente
            //Room.RoomStatus = (RoomStatus)RoomStatusComboBox.SelectedItem;
            //Room.HousekeeperStatus = (HousekeeperStatus)HouseKeeperComboBox.SelectedItem;

            Debug.WriteLine($"RoomTypeIdDIALOG Antes de guardar: {Room.RoomTypeId}");

            // Guardar los cambios en la base de datos
            //using (var context = new AppDbContext())
            //{
            //    if (Room.Id == 0) // Si es un nuevo registro
            //    {
            //        context.RoomTable.Add(Room);
            //    }
            //    else // Si es una actualización de un registro existente
            //    {
            //        context.RoomTable.Update(Room);
            //    }
            //
            //    context.SaveChanges(); // Guardar los cambios en la base de datos
            //}

            Debug.WriteLine($"RoomTypeIdDIALOG Despues de guardar: {Room.RoomTypeId}");

            DialogResult = true;
            Close();
        }






        private void ValidateFields()
        {
            bool isFormValid = !string.IsNullOrWhiteSpace(RoomKeyTextBox.Text) &&
                               RoomTypComboBox.SelectedValue != null &&
                               RoomStatusComboBox.SelectedItem != null &&
                               HouseKeeperComboBox.SelectedItem != null &&
                               RoomKeyTextBox.Text.Length <= 10;

            AddButton.IsEnabled = isFormValid;

        }

        private void OnTextChanged(object sender, RoutedEventArgs e)
        {
            ValidateFields();
        }

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            ValidateFields();
            //ReloadRoomTypes();
        }

        private bool IsRoomKeyDuplicate(string roomKey)
        {
            using (var context = new AppDbContext())
            {
                return context.RoomTable.Any(r => r.RoomKey == roomKey);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Room.IsSelected = false;
            Close();
        }
    }
}
