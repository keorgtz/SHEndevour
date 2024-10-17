using SHEndevour.Models;
using SHEndevour.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Lógica de interacción para ConfigurarSegmentoDialog.xaml
    /// </summary>
    public partial class ConfigurarSegmentoDialog : Window
    {
        
        public SegmentModel Segment { get; private set; }

        public ConfigurarSegmentoDialog(SegmentModel? segment = null)
        {
            InitializeComponent();
            

            if (segment != null)
            {
                Segment = segment;
                PopulateFields();
                Title = "Editar Segmento";
                AddEditSubtitle.Text = "Edición de Segmento";
                //room.IsSelected = false;
            }
            else
            {
                Segment = new SegmentModel();
                Title = "Añadir Segmento";
                AddEditSubtitle.Text = "Agregar un Nuevo Segmento";
            }



            DataContext = Segment;
            ValidateFields();
        }


        private void PopulateFields()
        {
            SegmentKeyTextBox.Text = Segment.SegmentKey;
            DescriptionTextBox.Text = Segment.Description;
        }

        private void OnAcceptClick(object sender, RoutedEventArgs e)
        {

            // Validar si la clave de la habitación ya existe
            if (Segment.SegmentKey != SegmentKeyTextBox.Text && IsSegmentKeyDuplicate(SegmentKeyTextBox.Text))
            {
                MessageBox.Show("La clave de segmento ya existe.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            // Asignar la clave del segmento si ha cambiado
            if (Segment.SegmentKey != SegmentKeyTextBox.Text)
            {
                Segment.SegmentKey = SegmentKeyTextBox.Text;
            }

            // Asignar la descripcion del segmento si ha cambiado
            if (Segment.Description != DescriptionTextBox.Text)
            {
                Segment.Description = DescriptionTextBox.Text;
            }


            DialogResult = true;
            Close();
        }







        private void ValidateFields()
        {
            bool isFormValid = !string.IsNullOrWhiteSpace(SegmentKeyTextBox.Text) &&
                               !string.IsNullOrWhiteSpace(DescriptionTextBox.Text);

            AddButton.IsEnabled = isFormValid;

        }

        private void OnTextChanged(object sender, RoutedEventArgs e)
        {
            ValidateFields();
        }


        private bool IsSegmentKeyDuplicate(string segmentKey)
        {
            using (var context = new AppDbContext())
            {
                return context.SegmentTable.Any(r => r.SegmentKey == segmentKey);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }
    }
}
