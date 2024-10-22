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
using SHEndevour.ViewModels.ControlRestrictionVM;
using SHEndevour.Views.ControlRestrictionView;

namespace SHEndevour
{
    
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;
        public MainWindow()
        {
            InitializeComponent();
            //Iniciamos al App cargando el HomeView
            MainContent.Content = new HomeView();
            // Establecer el DataContext como la clase App
            DataContext = this;
            
            HomeRButton.IsChecked = true;

            // Cargar la configuración de conexión
            var connectionSettings = DbConnectionSettings.LoadConnections();

            // Obtener el servidor predeterminado
            var defaultConnection = connectionSettings.FirstOrDefault(c => c.IsDefault);
            if (defaultConnection != null)
            {
                // Obtener el nombre del servidor
                string serverName = defaultConnection.GetServerName();

                // Establecer el título de la ventana con el nombre del servidor
                ServerName.Text = $"[{serverName}]";
            }
            else
            {
                ServerName.Text = "Sin Conexión";
            }

            MachineName.Text = System.Environment.MachineName;

        }

        public string? UserFirstname => App.CurrentUser?.FirstName;
        public string? UserRolename => App.CurrentUser?.Role?.Name;

        // = = = = = = = = = = = = Control Limiter = = = = = = = = = = = = = =
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            // Aplica los permisos del usuario actual a esta ventana
            App.PermissionService?.ApplyPermissions(this);
        }
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

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
                ExpandSidebar();
            }
            else
            {
                CollapseSidebar();
            }
            isSidebarCollapsed = !isSidebarCollapsed;
        }

        private void ExpandSidebar()
        {
            SidebarColumn.Width = GridLength.Auto;
            SetSidebarVisibility(Visibility.Visible);
            ToggleIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.ChevronDoubleLeft;
        }

        private void CollapseSidebar()
        {
            SidebarColumn.Width = GridLength.Auto; // Ajustar ancho cuando colapsado
            SetSidebarVisibility(Visibility.Collapsed);
            ToggleIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.ChevronDoubleRight;
        }

        private void SetSidebarVisibility(Visibility visibility)
        {
            TextInicio.Visibility = visibility;
            TextUsuarios.Visibility = visibility;
            TextRack.Visibility = visibility;
            TextConfig.Visibility = visibility;
            TextReportes.Visibility = visibility;
            TextColapsar.Visibility = visibility;
            TextLogout.Visibility = visibility;
            LoggedUserField.Visibility = visibility;
            SeparatorSidebar.Visibility = visibility;
        }

        private void ControlsButton_Click(object sender, RoutedEventArgs e)
        {
            var dashboardView = new PermissionsDashboardView
            {
                DataContext = new PermissionsDashboardViewModel()
            };
            dashboardView.Show();

        }

        private void RoleTemplateButton_Click(object sender, RoutedEventArgs e)
        {
            var dashboardView = new RoleTemplatesView();
            dashboardView.Show();

        }




        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =



    }
}