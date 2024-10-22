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

namespace SHEndevour.Views.Settings.Sales.Dialogs
{
    /// <summary>
    /// Lógica de interacción para ConfigurarPagosDialog.xaml
    /// </summary>
    public partial class ConfigurarPagosDialog : Window
    {
        public ConfigurarPagosDialog()
        {
            InitializeComponent();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            // Aplica los permisos del usuario actual a esta ventana
            App.PermissionService?.ApplyPermissions(this);
        }

    }
}
