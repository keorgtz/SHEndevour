using SHEndevour.Views.Settings.Rooms;
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
using SHEndevour.Views.Settings.Markets;
using RadioButton = System.Windows.Controls.RadioButton;
using UserControl = System.Windows.Controls.UserControl;

namespace SHEndevour.Views.Settings
{
    /// <summary>
    /// Lógica de interacción para MarketSetting.xaml
    /// </summary>
    public partial class MarketSetting : UserControl
    {
        public MarketSetting()
        {
            InitializeComponent();
            MarketConfigureView.Content = new ConfigurarHabitacion();
            SegmentNavButton.IsChecked = true;
        }

        private void MarketSettingNav_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton button) // Verificación de que el sender es un Button
            {
                string tag = button.Tag?.ToString() ?? string.Empty; // Manejo de nulo con ?? y ?? operator

                switch (tag)
                {
                    case "Segment":
                        MarketConfigureView.Content = new ConfigurarSegmento();
                        break;

                    case "Geo":
                        MarketConfigureView.Content = new ConfigurarOrigenGeo();
                        break;

                    default:
                        // Manejar un valor de tag no esperado si es necesario
                        break;
                }

            }
        }
    }
}
