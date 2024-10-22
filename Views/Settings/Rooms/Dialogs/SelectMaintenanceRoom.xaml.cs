using SHEndevour.ViewModels.Settings.Rooms;
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

namespace SHEndevour.Views.Settings.Rooms.Dialogs
{
    /// <summary>
    /// Lógica de interacción para SelectMaintenanceRoom.xaml
    /// </summary>
    public partial class SelectMaintenanceRoom : Window
    {
        public SelectMaintenanceRoom()
        {
            InitializeComponent();
            this.DataContext = new RoomManagementViewModel();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            // Aplica los permisos del usuario actual a esta ventana
            App.PermissionService?.ApplyPermissions(this);
        }
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =


        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtén el ViewModel del DataContext
            var viewModel = this.DataContext as RoomManagementViewModel;

            // Verifica si se ha seleccionado una habitación
            if (viewModel?.SelectedRoom != null)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una habitación.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Cierra el diálogo sin cambios
            this.DialogResult = false;
            this.Close();
        }



    }
}
