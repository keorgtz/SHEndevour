using SHEndevour.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Core;
using SHEndevour.ViewModels.Settings.Rooms;
using MessageBox = System.Windows.MessageBox;
using System.Collections.ObjectModel;
using ComboBox = System.Windows.Controls.ComboBox;

namespace SHEndevour.Views.Settings.Rooms.Dialogs
{
    public partial class AddEditMaintenanceDialog : Window
    {
        public RoomMaintenanceModel RoomMaintenance { get; private set; }

        public AddEditMaintenanceDialog(RoomMaintenanceModel? maintenance = null)
        {
            InitializeComponent();
            LoadRoomStatuses();
            LoadBlockTypes();


            if (maintenance != null)
            {
                RoomMaintenance = maintenance;
                PopulateFields(); // Llenar los campos con los datos del mantenimiento
                Title = "Editar Registro";
                AddEditSubtitle.Text = "Edición de Registro";
            }
            else
            {
                RoomMaintenance = new RoomMaintenanceModel();
                Title = "Añadir Registro";
                AddEditSubtitle.Text = "Agregar Nuevo Registro";
            }
            DataContext = RoomMaintenance;

            ValidateFields();
            
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            // Aplica los permisos del usuario actual a esta ventana
            App.PermissionService?.ApplyPermissions(this);
        }
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =


        // Cargar RoomStatuses
        private void LoadRoomStatuses()
        {
            // Cargar solo los estados "Bloqueado" y "Mantenimiento"
            var selectedStatuses = Enum.GetValues(typeof(RoomStatus))
                                        .Cast<RoomStatus>()
                                        .Where(status => status == RoomStatus.Bloqueado || status == RoomStatus.Mantenimiento)
                                        .ToArray();

            RoomStatusComboBox.ItemsSource = new ObservableCollection<RoomStatus>(selectedStatuses);
        }


        // Cargar BlockTypes
        private void LoadBlockTypes()
        {
            BlockTypeComboBox.ItemsSource = new ObservableCollection<BlockType>(Enum.GetValues(typeof(BlockType)).Cast<BlockType>());
        }



        //private void PopulateFields()
        //{
        //    RoomKeyTextBox.Text = Room.RoomKey;
        //    RoomTypComboBox.SelectedValue = Room.RoomTypeId;
        //    RoomStatusComboBox.SelectedItem = Room.RoomStatus;
        //    HouseKeeperComboBox.SelectedItem = Room.HousekeeperStatus;
        //}

        private void PopulateFields()
        {
            
                RoomKeyTextBox.Text = RoomMaintenance.RoomKey;
                RoomStatusComboBox.SelectedItem = RoomMaintenance.RoomStatus;
                CauseDescriptionTextBox.Text = RoomMaintenance.CauseDescription;
                BlockTypeComboBox.SelectedItem = RoomMaintenance.BlockType;

                // Cargar la fecha de finalización si es necesario
                if (RoomMaintenance.BlockType == BlockType.Programado && RoomMaintenance.EndDate.HasValue)
                {
                    EndDatePicker.SelectedDate = RoomMaintenance.EndDate.Value;
                }
                else
                {
                    EndDatePicker.SelectedDate = null; // Limpiar si no es programado
                }
            
        }



        private void OnAcceptClick(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                RoomMaintenance.RoomKey = RoomKeyTextBox.Text;
                RoomMaintenance.RoomStatus = (RoomStatus)RoomStatusComboBox.SelectedItem;
                RoomMaintenance.CauseDescription = CauseDescriptionTextBox.Text;
                RoomMaintenance.BlockType = (BlockType)BlockTypeComboBox.SelectedItem;

                if (RoomMaintenance.BlockType == BlockType.Programado)
                {
                    RoomMaintenance.EndDate = EndDatePicker.SelectedDate;
                }
                else
                {
                    RoomMaintenance.EndDate = null;
                }

                DialogResult = true;
                Close();
            }
        }

        private bool ValidateForm()
        {
            // Validar RoomKey
            if (string.IsNullOrWhiteSpace(RoomKeyTextBox.Text) || RoomKeyTextBox.Text.Length > 10)
            {
                MessageBox.Show("La clave de la habitación no puede estar vacía o tener más de 10 caracteres.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Validar RoomStatus
            if (RoomStatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estado de la habitación.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Validar descripción de la causa
            if (string.IsNullOrWhiteSpace(CauseDescriptionTextBox.Text))
            {
                MessageBox.Show("Debe proporcionar una descripción de la causa del bloqueo o mantenimiento.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Validar tipo de bloqueo
            if (BlockTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de bloqueo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Validar la fecha de terminación si el bloqueo es programado
            if ((BlockType)BlockTypeComboBox.SelectedItem == BlockType.Programado && EndDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Debe seleccionar una fecha de terminación para el bloqueo programado.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void ValidateFields()
        {
            AddButton.IsEnabled = !string.IsNullOrWhiteSpace(RoomKeyTextBox.Text) &&
                                  RoomStatusComboBox.SelectedItem != null &&
                                  BlockTypeComboBox.SelectedItem != null &&
                                  !string.IsNullOrWhiteSpace(CauseDescriptionTextBox.Text);
        }

        private void OnTextChanged(object sender, RoutedEventArgs e)
        {
            ValidateFields();
        }

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            ValidateFields();


            // Comprobar si el evento proviene del ComboBox de tipo de bloqueo
            if (sender is ComboBox comboBox && comboBox.Name == nameof(BlockTypeComboBox))
            {
                // Verificar si el item seleccionado es "Programado"
                if (comboBox.SelectedItem is BlockType selectedBlockType)
                {
                    // Habilitar o deshabilitar el DatePicker según el tipo de bloqueo seleccionado
                    EndDatePicker.IsEnabled = selectedBlockType == BlockType.Programado;
                }
            }

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonForSelectRoom_Click(object sender, RoutedEventArgs e)
        {
            var selectRoomDialog = new SelectMaintenanceRoom();

            // Abre el diálogo y verifica si el usuario seleccionó una habitación y confirmó
            if (selectRoomDialog.ShowDialog() == true)
            {
                // Recupera el RoomKey de la habitación seleccionada
                var selectedRoom = ((RoomManagementViewModel)selectRoomDialog.DataContext).SelectedRoom;
                if (selectedRoom != null)
                {
                    RoomKeyTextBox.Text = selectedRoom.RoomKey; // Asigna el RoomKey seleccionado al TextBox
                }
            }
        }

    }
}
