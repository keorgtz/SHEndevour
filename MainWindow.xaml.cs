using SHEndevour.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SHEndevour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        [DllImport("dwmapi.dll", PreserveSig = true)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        public MainWindow()
        {
            InitializeComponent();
            SetTitleBarColor(); //Funcion para Establecer el Tema del Sistema a la Ventana de la App
        }

        private void SetTitleBarColor()
        {
            var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            int useImmersiveDarkMode = 1; // 0 for light mode, 1 for dark mode
            DwmSetWindowAttribute(hwnd, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useImmersiveDarkMode, sizeof(int));
        }

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button) // Verificación de que el sender es un Button
            {
                string tag = button.Tag?.ToString() ?? string.Empty; // Manejo de nulo con ?? y ?? operator

                switch (tag)
                {
                    case "Inicio":
                        MainContent.Content = new HomeView();
                        break;
                    case "Usuarios":
                        MainContent.Content = new UsersView();
                        break;
                    case "Configuración":
                        MainContent.Content = new SettingView();
                        break;
                    default:
                        // Manejar un valor de tag no esperado si es necesario
                        break;
                }
            }
        }
    }
}