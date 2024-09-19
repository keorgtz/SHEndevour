using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHEndevour.Models;
using SHEndevour.Utilities;
using SHEndevour.Views;
using System.Windows;
using System.Windows.Media;
using System.Configuration;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace SHEndevour
{
    public partial class App : Application
    {

        public static UserModel CurrentUser { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Leer el valor de escala desde App.config
            string scaleFactorConfig = ConfigurationManager.AppSettings["ScaleFactor"];
            double scaleFactor = double.TryParse(scaleFactorConfig, out double result) ? result : 1.0;

            // Aplicar el valor globalmente
            Application.Current.Resources["GlobalScaleFactor"] = scaleFactor;


            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =


            // Crear el servicio y el contexto
            using (var context = new AppDbContext())
            {
                try
                {
                    // Crear la base de datos y las tablas si no existen
                    context.Database.EnsureCreated();
                    Console.WriteLine("Base de datos y tablas aseguradas.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                    Environment.Exit(1);
                }
            }

            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

            //Inicializador de Administracion
            AdminUserInitializer.EnsureAdminUser();

            


        }




    }
}