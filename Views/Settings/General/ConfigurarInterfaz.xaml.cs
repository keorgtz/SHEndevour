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
using System.Configuration;
using UserControl = System.Windows.Controls.UserControl;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace SHEndevour.Views.Settings.General
{
    /// <summary>
    /// Lógica de interacción para ConfigurarInterfaz.xaml
    /// </summary>
    public partial class ConfigurarInterfaz : UserControl
    {

        // Propiedad para el valor de escala
        public double ScaleValue { get; set; }

        public ConfigurarInterfaz()
        {
            InitializeComponent();

            // Cargar el valor inicial desde el App.config
            string? scaleFactorConfig = ConfigurationManager.AppSettings["ScaleFactor"];
            ScaleValue = double.TryParse(scaleFactorConfig, out double result) ? result : 1.0;

            // Enlazar el valor al control Slider
            DataContext = this;

            Loaded += CustomControl_Loaded;  // Suscribe al evento Loaded
        }

        // Se llama cuando el UserControl está completamente cargado
        private void CustomControl_Loaded(object sender, EventArgs e)
        {
            // Aplica los permisos del usuario actual a este UserControl
            App.PermissionService?.ApplyPermissions(this);
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            // Actualizar el valor en App.config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ScaleFactor"].Value = ScaleValue.ToString("F1");
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            // Actualizar el recurso global para reflejar el cambio inmediatamente
            Application.Current.Resources["GlobalScaleFactor"] = ScaleValue;

            MessageBox.Show("Configuracion Establecida!\n Reinicie la Aplicacion para Efectuar los Cambios", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
        }


    }
}
