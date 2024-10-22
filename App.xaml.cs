using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHEndevour.Models;
using SHEndevour.Utilities;
using SHEndevour.Views;
using System.Windows;
using System.IO;
using System.Windows.Media;
using System.Configuration;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using SHEndevour.Services.Maintenance;
using SHEndevour.Views.DatabaseView;
using SHEndevour.Services;

namespace SHEndevour
{
    public partial class App : Application
    {

        public static UserModel? CurrentUser { get; set; }
        public static PermissionService? PermissionService { get; private set; }

        private MaintenanceService? _maintenanceService;


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            InitializeApplication();
            PermissionService = new PermissionService();  // Inicializa el servicio de permisos.
        }

        private void InitializeApplication()
        {
            // Crear el servicio y el contexto
            using (var context = new AppDbContext())
            {
                try
                {
                    // Verificar la conexión a la base de datos
                    if (!context.Database.CanConnect())
                    {
                        // Si no se puede conectar, abrir la vista para crear la base de datos
                        var dbConnectionView = new DbConnectionView();
                        dbConnectionView.Closed += (s, args) => InitializeApplication(); // Reiniciar la inicialización al cerrar
                        dbConnectionView.ShowDialog(); // Cambiar Show() por ShowDialog()
                        return; // No continuar con la inicialización normal
                    }

                    Console.WriteLine("Conexión a la base de datos establecida.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Environment.Exit(1);
                }
            }

            // Inicializador de Administracion
            AdminUserInitializer.EnsureAdminUser();


            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
            //Escalado de la APP

            // Leer el valor de escala desde App.config
            string? scaleFactorConfig = ConfigurationManager.AppSettings["ScaleFactor"];
            double scaleFactor = double.TryParse(scaleFactorConfig, out double result) ? result : 1.0;

            // Aplicar el valor globalmente
            Application.Current.Resources["GlobalScaleFactor"] = scaleFactor;


            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

            //SERVICIO DE MANTENIMIENTO
            // Inicia el servicio de mantenimiento al iniciar la aplicación
            _maintenanceService = new MaintenanceService();




            //Log de Errores:

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                var exception = (Exception)args.ExceptionObject;
                File.WriteAllText("error.log", exception.ToString());

            };


        }


        protected override void OnExit(ExitEventArgs e)
        {
            // Detener el Timer antes de que la aplicación cierre
            _maintenanceService?.StopTimer();
            base.OnExit(e);
        }


    }
}