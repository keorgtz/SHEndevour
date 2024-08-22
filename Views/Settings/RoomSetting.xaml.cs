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
using RadioButton = System.Windows.Controls.RadioButton;
using UserControl = System.Windows.Controls.UserControl;
using SHEndevour.Views.Settings.Rooms;

namespace SHEndevour.Views.Settings
{
    /// <summary>
    /// Lógica de interacción para RoomSetting.xaml
    /// </summary>
    public partial class RoomSetting : UserControl
    {
        public RoomSetting()
        {
            InitializeComponent();
            RoomConfigureView.Content = new ConfigurarHabitacion();
            HabitacionesNavButton.IsChecked = true;
        }

        private void RoomSettingNav_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton button) // Verificación de que el sender es un Button
            {
                string tag = button.Tag?.ToString() ?? string.Empty; // Manejo de nulo con ?? y ?? operator

                switch (tag)
                {
                    case "Habitaciones":
                        RoomConfigureView.Content = new ConfigurarHabitacion();
                        break;

                    case "HabitacionesTipos":
                        RoomConfigureView.Content = new ConfigurarTipoDeHabitacion();
                        break;

                    default:
                        // Manejar un valor de tag no esperado si es necesario
                        break;
                }

            }

        }

    }
}
