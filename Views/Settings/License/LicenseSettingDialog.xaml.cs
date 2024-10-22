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

namespace SHEndevour.Views.Settings.License
{
    /// <summary>
    /// Lógica de interacción para LicenseSettingDialog.xaml
    /// </summary>
    public partial class LicenseSettingDialog : Window
    {
        public LicenseSettingDialog()
        {
            InitializeComponent();
            LicenseScreen.Content = new LicenseSettings();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            // Aplica los permisos del usuario actual a esta ventana
            App.PermissionService?.ApplyPermissions(this);
        }
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =


    }
}
