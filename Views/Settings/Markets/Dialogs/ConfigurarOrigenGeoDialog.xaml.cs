using SHEndevour.Models;
using SHEndevour.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace SHEndevour.Views.Settings.Markets.Dialogs
{
    /// <summary>
    /// Lógica de interacción para ConfigurarOrigenGeoDialog.xaml
    /// </summary>
    public partial class ConfigurarOrigenGeoDialog : Window
    {
        public GeoOriginModel Geo { get; private set; }

        public ConfigurarOrigenGeoDialog(GeoOriginModel? geo = null)
        {
            InitializeComponent();


            if (geo != null)
            {
                Geo = geo;
                PopulateFields();
                Title = "Editar Origen de Segmento";
                AddEditSubtitle.Text = "Edición de Origen";
            }
            else
            {
                Geo = new GeoOriginModel();
                Title = "Añadir Origen de Segmento";
                AddEditSubtitle.Text = "Agregar un Nuevo Origen";
            }



            DataContext = Geo;
            ValidateFields();
        }


        private void PopulateFields()
        {
            GeoKeyTextBox.Text = Geo.GeoKey;
            DescriptionTextBox.Text = Geo.Description;
        }

        private void OnAcceptClick(object sender, RoutedEventArgs e)
        {

            // Validar si la clave de la habitación ya existe
            if (Geo.GeoKey != GeoKeyTextBox.Text && IsGeoKeyDuplicate(GeoKeyTextBox.Text))
            {
                MessageBox.Show("La clave de Origen ya existe.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            // Asignar la clave del segmento si ha cambiado
            if (Geo.GeoKey != GeoKeyTextBox.Text)
            {
                Geo.GeoKey = GeoKeyTextBox.Text;
            }

            // Asignar la descripcion del segmento si ha cambiado
            if (Geo.Description != DescriptionTextBox.Text)
            {
                Geo.Description = DescriptionTextBox.Text;
            }


            DialogResult = true;
            Close();
        }







        private void ValidateFields()
        {
            bool isFormValid = !string.IsNullOrWhiteSpace(GeoKeyTextBox.Text) &&
                               !string.IsNullOrWhiteSpace(DescriptionTextBox.Text);

            AddButton.IsEnabled = isFormValid;

        }

        private void OnTextChanged(object sender, RoutedEventArgs e)
        {
            ValidateFields();
        }


        private bool IsGeoKeyDuplicate(string geoKey)
        {
            using (var context = new AppDbContext())
            {
                return context.GeoOriginTable.Any(r => r.GeoKey == geoKey);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }
    }
}
