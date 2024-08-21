using Microsoft.EntityFrameworkCore;
using SHEndevour.Utilities;
using SHEndevour.Views;
using System.Windows;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.MessageBox;

namespace SHEndevour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            // Cargar los datos del usuario logueado
            if (App.CurrentUser != null)
            {
                UsernameTextBlock.Text = $"Username: {App.CurrentUser.Username}";
                RoleTextBlock.Text = $"Role: {App.CurrentUser.Role?.Name}";
            }
            else
            {
                UsernameTextBlock.Text = "No user logged in";
                RoleTextBlock.Text = "No Role available";
            }

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
                        MainContent.Content = new UserView();
                        break;
                    case "Configuracion":
                        MainContent.Content = new SettingView();
                        break;

                    default:
                        // Manejar un valor de tag no esperado si es necesario
                        break;
                }
            }
        }

        private void ButtonReporting_Click(object sender, RoutedEventArgs e)
        {

            // Crear y mostrar la nueva ventana
            ReportDesignerWindow reportDesignerWindow = new ReportDesignerWindow();
            reportDesignerWindow.Show();


            // Cerrar la ventana actual
            this.Close();
        }

        private void ViewReport_Click(object sender, RoutedEventArgs e)
        {
            ReportViewerWindow reportViewerWindow = new ReportViewerWindow();
            reportViewerWindow.Show();

            this.Close();
        }

    }
}