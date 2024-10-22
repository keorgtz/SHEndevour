using SHEndevour.ViewModels;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Printing;
using DevExpress.XtraReports.UI;
using UserControl = System.Windows.Controls.UserControl;
using SHEndevour.Repositories.Reports;

namespace SHEndevour.Views
{
    public partial class UserView : UserControl
    {
         // Columna por defecto para la búsqueda
        public UserView()
        {
            InitializeComponent();
            this.DataContext = new UserManagementViewModel();
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
