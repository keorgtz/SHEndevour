using SHEndevour.Utilities;
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
using System.Windows.Shapes;
using System.Data.SqlClient;
using MessageBox = System.Windows.MessageBox;

namespace SHEndevour.Views.DatabaseView
{

    public partial class DatabaseConnectionDialog : Window
    {
        public DbConnectionSettings ConnectionSettings { get; set; }

        public DatabaseConnectionDialog()
        {
            InitializeComponent();
            ConnectionSettings = new DbConnectionSettings();
        }

        private void Verify_Click(object sender, RoutedEventArgs e)
        {
            // Recoger los datos de los campos
            ConnectionSettings.Name = NameTextBox.Text;
            ConnectionSettings.Description = DescriptionTextBox.Text;
            ConnectionSettings.ServerName = ServerNameTextBox.Text;
            ConnectionSettings.Instance = InstanceTextBox.Text; // Instancia opcional
            ConnectionSettings.Database = DatabaseTextBox.Text;
            ConnectionSettings.UserId = UserIdTextBox.Text;
            ConnectionSettings.Password = PasswordTextBox.Password;
            ConnectionSettings.TrustServerCertificate = TrustServerCertificateCheckBox.IsChecked == true;

            try
            {
                // Probar la conexión
                using (var connection = new SqlConnection(ConnectionSettings.GetConnectionString()))
                {
                    connection.Open();
                    MessageBox.Show("Conexión exitosa!", "Prueba de Conexión", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Validar que todos los campos requeridos estén completos
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(ServerNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(DatabaseTextBox.Text) || string.IsNullOrWhiteSpace(UserIdTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordTextBox.Password))
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Campos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Guardar los datos
            ConnectionSettings.Name = NameTextBox.Text;
            ConnectionSettings.Description = DescriptionTextBox.Text;
            ConnectionSettings.ServerName = ServerNameTextBox.Text;
            ConnectionSettings.Instance = InstanceTextBox.Text; // Guardar la instancia
            ConnectionSettings.Database = DatabaseTextBox.Text;
            ConnectionSettings.UserId = UserIdTextBox.Text;
            ConnectionSettings.Password = PasswordTextBox.Password;
            ConnectionSettings.TrustServerCertificate = TrustServerCertificateCheckBox.IsChecked == true;

            // Guardar las conexiones en appsettings.json
            var connections = DbConnectionSettings.LoadConnections();
            connections.RemoveAll(c => c.Name == ConnectionSettings.Name); // Eliminar cualquier conexión existente con el mismo nombre
            connections.Add(ConnectionSettings);

            DbConnectionSettings.SaveConnections(connections);
            MessageBox.Show("Conexión guardada correctamente.", "Guardar Conexión", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
            Close();
        }

        
    }
}
