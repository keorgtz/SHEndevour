using SHEndevour.Models;
using SHEndevour.Utilities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using MessageBox = System.Windows.MessageBox;

namespace SHEndevour.Views.Settings.Rooms.Dialogs
{
    public partial class AddEditRoomDialog : Window
    {
        public RoomModel Room { get; private set; }

        public AddEditRoomDialog(RoomModel room = null)
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
                room.IsSelected = false;
            }
            else
            {
                Room = new RoomModel();
                Title = "Añadir Habitación";
                AddEditSubtitle.Text = "Agregar una Nueva Habitación";
            }

            DataContext = Room;
            ValidateFields();
        }

        private void LoadRoomTypes()
        {
            using (var context = new AppDbContext())
            {
                var roomTypes = context.RoomTypeTable.ToList();
                RoomTypeComboBox.ItemsSource = roomTypes;
                RoomTypeComboBox.DisplayMemberPath = "Description";
                RoomTypeComboBox.SelectedValuePath = "Id";
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
            RoomTypeComboBox.SelectedValue = Room.RoomTypeId;
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

            if (RoomTypeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de habitación.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Room.RoomKey != RoomKeyTextBox.Text && IsRoomKeyDuplicate(RoomKeyTextBox.Text))
            {
                MessageBox.Show("La clave de la habitación ya existe.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Actualizar los valores del modelo
            Room.RoomKey = RoomKeyTextBox.Text;
            Room.RoomTypeId = (int)RoomTypeComboBox.SelectedValue;
            Room.RoomStatus = (RoomStatus)RoomStatusComboBox.SelectedItem;
            Room.HousekeeperStatus = (HousekeeperStatus)HouseKeeperComboBox.SelectedItem;

            DialogResult = true;
            Room.IsSelected = false;
            Close();
        }

        private void ValidateFields()
        {
            bool isFormValid = !string.IsNullOrWhiteSpace(RoomKeyTextBox.Text) &&
                               RoomTypeComboBox.SelectedValue != null &&
                               RoomStatusComboBox.SelectedItem != null &&
                               HouseKeeperComboBox.SelectedItem != null &&
                               RoomKeyTextBox.Text.Length <= 10;

            AddButton.IsEnabled = isFormValid;
            Room.IsSelected = false;
        }

        private void OnTextChanged(object sender, RoutedEventArgs e)
        {
            ValidateFields();
        }

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            ValidateFields();
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
