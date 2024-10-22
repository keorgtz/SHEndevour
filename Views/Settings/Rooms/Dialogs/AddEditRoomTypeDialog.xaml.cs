using DevExpress.Xpf.Core;
using SHEndevour.Models;
using SHEndevour.Utilities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;

namespace SHEndevour.Views.Settings.Rooms.Dialogs
{
    public partial class AddEditRoomTypeDialog : Window
    {
        public RoomTypeModel RoomTypeD { get; private set; }

        public AddEditRoomTypeDialog(RoomTypeModel roomType = null)
        {
            InitializeComponent();

            if (roomType != null)
            {
                RoomTypeD = roomType;
                PopulateFields(); // Poblar los campos si se está editando un tipo de habitación
                Title = "Editar Tipo de Habitación";
                AddEditSubtitle.Text = "Edición de Tipo de Habitación";
                roomType.IsSelected = false;
            }
            else
            {
                RoomTypeD = new RoomTypeModel();
                Title = "Añadir Tipo de Habitación";
                AddEditSubtitle.Text = "Agregar un Nuevo Tipo de Habitación";
            }

            DataContext = RoomTypeD;
            ValidateFields(); // Inicializar la validación de campos
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            // Aplica los permisos del usuario actual a esta ventana
            App.PermissionService?.ApplyPermissions(this);
        }
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        private void PopulateFields()
        {
            RoomTypeKeyTextBox.Text = RoomTypeD.RoomTypeKey;
            RoomTypeDescriptionBox.Text = RoomTypeD.Description;
            SingleTextBox.Text = RoomTypeD.SingleRate.ToString("F2");
            SingleMinTextBox.Text = RoomTypeD.MinSingleRate.ToString("F2");
            DoubleTextBox.Text = RoomTypeD.DoubleRate.ToString("F2");
            DoubleMinTextBox.Text = RoomTypeD.MinDoubleRate.ToString("F2");
            TripleTextBox.Text = RoomTypeD.TripleRate.ToString("F2");
            TripleMinTextBox.Text = RoomTypeD.MinTripleRate.ToString("F2");
            QuadrupleTextBox.Text = RoomTypeD.QuadrupleRate.ToString("F2");
            QuadrupleMinTextBox.Text = RoomTypeD.MinQuadrupleRate.ToString("F2");
        }

        private void OnAcceptClick(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(SingleTextBox.Text, out var singleRate) ||
                !decimal.TryParse(SingleMinTextBox.Text, out var minSingleRate) ||
                !decimal.TryParse(DoubleTextBox.Text, out var doubleRate) ||
                !decimal.TryParse(DoubleMinTextBox.Text, out var minDoubleRate) ||
                !decimal.TryParse(TripleTextBox.Text, out var tripleRate) ||
                !decimal.TryParse(TripleMinTextBox.Text, out var minTripleRate) ||
                !decimal.TryParse(QuadrupleTextBox.Text, out var quadrupleRate) ||
                !decimal.TryParse(QuadrupleMinTextBox.Text, out var minQuadrupleRate))
            {
                MessageBox.Show("Por favor, ingrese valores válidos para las tarifas.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //RoomTypeD.IsSelected = false;

            // Actualizar solo los valores que han sido modificados
            RoomTypeD.RoomTypeKey = RoomTypeKeyTextBox.Text;
            RoomTypeD.Description = RoomTypeDescriptionBox.Text;
            RoomTypeD.SingleRate = singleRate;
            RoomTypeD.MinSingleRate = minSingleRate;
            RoomTypeD.DoubleRate = doubleRate;
            RoomTypeD.MinDoubleRate = minDoubleRate;
            RoomTypeD.TripleRate = tripleRate;
            RoomTypeD.MinTripleRate = minTripleRate;
            RoomTypeD.QuadrupleRate = quadrupleRate;
            RoomTypeD.MinQuadrupleRate = minQuadrupleRate;

            DialogResult = true;
            Close();
        }

        private void ValidateFields()
        {
            bool isFormValid = !string.IsNullOrWhiteSpace(RoomTypeKeyTextBox.Text) &&
                               !string.IsNullOrWhiteSpace(RoomTypeDescriptionBox.Text) &&
                               decimal.TryParse(SingleTextBox.Text, out _) &&
                               decimal.TryParse(SingleMinTextBox.Text, out _) &&
                               decimal.TryParse(DoubleTextBox.Text, out _) &&
                               decimal.TryParse(DoubleMinTextBox.Text, out _) &&
                               decimal.TryParse(TripleTextBox.Text, out _) &&
                               decimal.TryParse(TripleMinTextBox.Text, out _) &&
                               decimal.TryParse(QuadrupleTextBox.Text, out _) &&
                               decimal.TryParse(QuadrupleMinTextBox.Text, out _);

            AddButton.IsEnabled = isFormValid;
            //RoomTypeD.IsSelected = false;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateFields();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
