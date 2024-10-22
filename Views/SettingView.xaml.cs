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
using SHEndevour.Views.Settings;
using SHEndevour.Views.Settings.License;
using RadioButton = System.Windows.Controls.RadioButton;
using UserControl = System.Windows.Controls.UserControl;

namespace SHEndevour.Views
{
    /// <summary>
    /// Lógica de interacción para SettingView.xaml
    /// </summary>
    public partial class SettingView : UserControl
    {
        public SettingView()
        {
            InitializeComponent();
            settingScreen.Content = new RoomSetting();
            RoomBTNSide.IsChecked = true;
            Loaded += CustomControl_Loaded;  // Suscribe al evento Loaded
        }

        // Se llama cuando el UserControl está completamente cargado
        private void CustomControl_Loaded(object sender, EventArgs e)
        {
            // Aplica los permisos del usuario actual a este UserControl
            App.PermissionService?.ApplyPermissions(this);
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton button) // Verificación de que el sender es un Button
            {
                string tag = button.Tag?.ToString() ?? string.Empty; // Manejo de nulo con ?? y ?? operator

                switch (tag)
                {
                    case "Rooms":
                        settingScreen.Content = new RoomSetting();
                        break;

                    case "Generals":
                        settingScreen.Content = new GeneralSetting();
                        break;

                    case "License":
                        settingScreen.Content = new LicenseSettings();
                        break;

                    case "Market":
                        settingScreen.Content = new MarketSetting();
                        break;

                    default:
                        // Manejar un valor de tag no esperado si es necesario
                        break;
                }

            }

        }

        private void LicenseButton_Click(object sender, RoutedEventArgs e)
        {
            var licenseScreen = new LicenseSettingDialog();
            licenseScreen.Show();
        }



    }
}
