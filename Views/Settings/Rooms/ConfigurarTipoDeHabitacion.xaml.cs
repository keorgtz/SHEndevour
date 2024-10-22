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
            Loaded += CustomControl_Loaded;  // Suscribe al evento Loaded
        }

        // Se llama cuando el UserControl está completamente cargado
        private void CustomControl_Loaded(object sender, EventArgs e)
        {
            // Aplica los permisos del usuario actual a este UserControl
            App.PermissionService?.ApplyPermissions(this);
        }
    }
}
