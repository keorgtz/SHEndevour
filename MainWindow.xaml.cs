using DevExpress.Drawing.Internal.Fonts;
using Microsoft.EntityFrameworkCore;
using SHEndevour.Utilities;
using SHEndevour.Views;
using SHEndevour.AppReports;
using SHEndevour.Models;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.MessageBox;
using Application = System.Windows.Application;

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
            //Iniciamos al App cargando el HomeView
            MainContent.Content = new HomeView();
            // Establecer el DataContext como la clase App
            DataContext = this;

            // Cargar los datos del usuario logueado
            //if (App.CurrentUser != null)
            //{
            //    UsernameTextBlock.Text = $"Username: {App.CurrentUser.Username}";
            //}
            //else
            //{
            //    UsernameTextBlock.Text = "No user logged in";
            //}

        }

        public string UserFirstname => App.CurrentUser.FirstName;
        public string UserRolename => App.CurrentUser.Role.Name;



        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.RadioButton button) // Verificación de que el sender es un Button
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
            ReportSelectionWindow reportSelectionWindow = new ReportSelectionWindow();
            reportSelectionWindow.Show();

        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Limpia la información del usuario autenticado
            App.CurrentUser = null;

            // Abre la ventana de login
            var loginWindow = new LoginWindow();
            loginWindow.Show();

            // Cierra la ventana principal
            this.Close();
        }

    }
}