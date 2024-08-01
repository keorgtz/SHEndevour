using SHEndevour.Utilities;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SHEndevour
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new AppDbContext())
            {
                // Este método crea la base de datos si no existe
                context.Database.EnsureCreated();
            }

            Console.WriteLine("Base de datos y tabla Users creadas (si no existían).");
        }
    }

}
