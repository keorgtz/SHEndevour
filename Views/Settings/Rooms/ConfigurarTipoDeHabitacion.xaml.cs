using DevExpress.Emf;
using SHEndevour.Models;
using SHEndevour.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace SHEndevour.Views.Settings.Rooms
{
    
    public partial class ConfigurarTipoDeHabitacion : UserControl
    {
        public ConfigurarTipoDeHabitacion()
        {
            InitializeComponent();
            this.DataContext = new RoomTypeManagementViewModel();
        }

        // Evento para cuando el CheckBox en el encabezado se chequea
        private void RoomTypeGridCheck_Checked(object sender, RoutedEventArgs e)
        {
            // Obtén la colección de usuarios desde el DataContext
            var viewModel = DataContext as RoomTypeManagementViewModel;

            if (viewModel != null)
            {
                foreach (var roomtype in viewModel.RoomTypes)
                {
                    roomtype.IsSelected = true;
                }

                // Forzar la actualización visual del DataGrid
                RoomTypeDataGrid.Items.Refresh();

            }
        }

        // Evento para cuando el CheckBox en el encabezado se deschequea
        private void RoomTypeGridCheck_Unchecked(object sender, RoutedEventArgs e)
        {
                        // Obtén la colección de usuarios desde el DataContext
            var viewModel = DataContext as RoomTypeManagementViewModel;

            if (viewModel != null)
            {
                foreach (var roomtype in viewModel.RoomTypes)
                {
                    roomtype.IsSelected = false;
                }

                // Forzar la actualización visual del DataGrid
                RoomTypeDataGrid.Items.Refresh();

            }
        }
    }
}
