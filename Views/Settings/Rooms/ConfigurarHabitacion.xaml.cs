using SHEndevour.ViewModels.Settings.Rooms;
using SHEndevour.Models;
using SHEndevour.ViewModels;
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
    
    public partial class ConfigurarHabitacion : UserControl
    {
        public ConfigurarHabitacion()
        {
            InitializeComponent();
            this.DataContext = new RoomManagementViewModel();
        }

        // Evento para cuando el CheckBox en el encabezado se chequea
        private void RoomGridCheck_Checked(object sender, RoutedEventArgs e)
        {
            // Obtén la colección de usuarios desde el DataContext
            var viewModel = DataContext as RoomManagementViewModel;

            if (viewModel != null)
            {
                foreach (var room in viewModel.Rooms)
                {
                    room.IsSelected = true;
                }

                // Forzar la actualización visual del DataGrid
                RoomDataGrid.Items.Refresh();

            }
        }

        // Evento para cuando el CheckBox en el encabezado se deschequea
        private void RoomGridCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            // Obtén la colección de usuarios desde el DataContext
            var viewModel = DataContext as RoomManagementViewModel;

            if (viewModel != null)
            {
                foreach (var room in viewModel.Rooms)
                {
                    room.IsSelected = false;
                }

                // Forzar la actualización visual del DataGrid
                RoomDataGrid.Items.Refresh();

            }
        }

    }
}
