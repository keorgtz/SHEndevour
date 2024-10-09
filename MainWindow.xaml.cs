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
using System.Windows.Media.Animation;

namespace SHEndevour
{
    
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //Iniciamos al App cargando el HomeView
            MainContent.Content = new HomeView();
            // Establecer el DataContext como la clase App
            DataContext = this;

           

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
                    case "Rack":
                        MainContent.Content = new HotelRack();
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



        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        private bool isSidebarCollapsed = false;

        private void ToggleSidebar_Click(object sender, RoutedEventArgs e)
        {
            if (isSidebarCollapsed)
            {
                // Expande el sidebar
                SidebarColumn.Width = GridLength.Auto; // Tamaño original
                TextInicio.Visibility = Visibility.Visible; // Mostrar texto
                TextUsuarios.Visibility = Visibility.Visible; // Mostrar texto
                TextRack.Visibility = Visibility.Visible; // Mostrar texto
                TextConfig.Visibility = Visibility.Visible; // Mostrar texto
                TextReportes.Visibility = Visibility.Visible; // Mostrar texto
                TextColapsar.Visibility = Visibility.Visible; // Mostrar texto
                TextLogout.Visibility = Visibility.Visible; // Mostrar texto
                LoggedUserField.Visibility = Visibility.Visible; // Mostrar texto
                SeparatorSidebar.Visibility = Visibility.Visible; // Mostrar separador

                ToggleIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.ChevronDoubleLeft;
            }
            else
            {
                // Colapsa el sidebar
                SidebarColumn.Width = GridLength.Auto; // Solo mostrar iconos
                TextInicio.Visibility = Visibility.Collapsed; // Ocultar texto
                TextUsuarios.Visibility = Visibility.Collapsed; // Mostrar texto
                TextRack.Visibility = Visibility.Collapsed; // Mostrar texto
                TextConfig.Visibility = Visibility.Collapsed; // Mostrar texto
                TextReportes.Visibility = Visibility.Collapsed; // Mostrar texto
                TextColapsar.Visibility = Visibility.Collapsed; // Mostrar texto
                TextLogout.Visibility = Visibility.Collapsed; // Mostrar texto
                LoggedUserField.Visibility = Visibility.Collapsed; // Mostrar texto
                SeparatorSidebar.Visibility = Visibility.Collapsed; // Mostrar separador

                ToggleIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.ChevronDoubleRight;
            }

            isSidebarCollapsed = !isSidebarCollapsed; // Alternar estado
        }





        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =



    }
}