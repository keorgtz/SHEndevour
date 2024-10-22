using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using SHEndevour.Models;
using MessageBox = System.Windows.MessageBox;
using SHEndevour.Utilities;
using SHEndevour.Views.DatabaseView;


namespace SHEndevour.Views
{
    public partial class LoginWindow : Window
    {
        private readonly AppDbContext _context;

        public LoginWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();

            // Cargar la configuración de conexión
            var connectionSettings = DbConnectionSettings.LoadConnections();

            // Obtener el servidor predeterminado
            var defaultConnection = connectionSettings.FirstOrDefault(c => c.IsDefault);
            if (defaultConnection != null)
            {
                // Obtener el nombre del servidor
                string serverName = defaultConnection.GetServerName();

                // Establecer el título de la ventana con el nombre del servidor
                SubTitle.Text = $"[{serverName}]";
            }
            else
            {
                SubTitle.Text = "Sin Conexión";
            }

        }



        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Verifica las credenciales e incluye el rol del usuario
            var user = _context.Users
                                     .Include(u => u.Role) // Incluye el rol asociado
                                     .SingleOrDefault(u => u.Username == username);

            if (user != null && PasswordHelper.VerifyPassword(password, user.Password))
            {
                // Almacena la información del usuario autenticado
                App.CurrentUser = user;

                // Abre la ventana principal de la aplicación
                var mainWindow = new MainWindow(); // Cambia MainWindow por el nombre de tu ventana principal
                mainWindow.Show();

                // Cierra la ventana de login
                this.Close();

            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrecta");
            }
        }

        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            // Aquí debes verificar la contraseña hasheada
            return inputPassword == storedPassword; // Reemplaza con la verificación de hash real
        }

        private void DbView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var dbConnectView = new DbConnectionView(); // Cambia MainWindow por el nombre de tu ventana principal
            dbConnectView.Show();
        }
    }
}