using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace SHEndevour.Utilities
{
    public class DbConnectionSettings
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ServerName { get; set; } // Nuevo campo para el nombre o IP del servidor
        public string? Instance { get; set; } // Nuevo campo para la instancia
        public string? Database { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
        public bool TrustServerCertificate { get; set; }
        public bool IsDefault { get; set; }

        // Nueva ubicación para el archivo appsettings.json en la carpeta AppData
        private static readonly string AppSettingsFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SHEndevour", "appsettings.json"
        );

        // Crear la carpeta en AppData si no existe
        private static void EnsureDirectoryExists()
        {
            var directoryPath = Path.GetDirectoryName(AppSettingsFilePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        public string GetConnectionString()
        {
            // Incorporar la instancia del servidor en la cadena de conexión
            var server = string.IsNullOrWhiteSpace(Instance) ? ServerName : $"{ServerName}\\{Instance}";
            return $"Server={server};Database={Database};User Id={UserId};Password={Password};TrustServerCertificate={TrustServerCertificate};";
        }

        // Cargar conexiones del archivo appsettings.json en la ubicación de AppData
        public static List<DbConnectionSettings> LoadConnections()
        {
            // Asegurarse de que el directorio existe antes de intentar acceder al archivo
            EnsureDirectoryExists();

            if (!File.Exists(AppSettingsFilePath))
            {
                // Si el archivo no existe, crear uno con una conexión predeterminada
                var defaultConnection = new List<DbConnectionSettings>
                {
                    new DbConnectionSettings
                    {
                        Name = "Main LocalDB",
                        Description = "Base de Datos Local",
                        ServerName = "localhost",
                        Instance = "SQLEXPRESS",
                        Database = "endevour_db",
                        UserId = "sa",
                        Password = "InfoHotel01",
                        TrustServerCertificate = true,
                        IsDefault = true
                    }
                };

                SaveConnections(defaultConnection);
                return defaultConnection;
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(AppSettingsFilePath)!) // BasePath debe ser el directorio del archivo de configuración
                .AddJsonFile(AppSettingsFilePath, optional: false, reloadOnChange: true)
                .Build();

            var connectionSettings = new List<DbConnectionSettings>();
            configuration.GetSection("ConnectionStrings").Bind(connectionSettings);

            return connectionSettings;
        }

        // Función para obtener el nombre del servidor
        public string GetServerName()
        {
            string serverName = string.Empty;

            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT @@SERVERNAME", connection))
                    {
                        var fullServerName = command.ExecuteScalar()?.ToString();
                        if (!string.IsNullOrEmpty(fullServerName))
                        {
                            // Dividir el nombre del servidor en base a la barra invertida y tomar el primer elemento
                            serverName = fullServerName.Split('\\')[0]; // Esto toma solo la parte del nombre del equipo
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones (como problemas de conexión)
                System.Windows.MessageBox.Show($"Error al obtener el nombre del servidor: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            return serverName;
        }



        // Guardar conexiones en appsettings.json en la ubicación de AppData
        public static void SaveConnections(List<DbConnectionSettings> connections)
        {
            try
            {
                // Asegurarse de que el directorio existe antes de guardar el archivo
                EnsureDirectoryExists();

                var json = JsonSerializer.Serialize(new { ConnectionStrings = connections }, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(AppSettingsFilePath, json);
            }
            catch (IOException ex)
            {
                // Manejar errores de E/S, como si el archivo está en uso o no se puede acceder
                System.Windows.MessageBox.Show($"Error al guardar conexiones en {AppSettingsFilePath}: {ex.Message}", "Error de E/S", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Manejar errores de permisos, como falta de acceso de escritura en la carpeta
                System.Windows.MessageBox.Show($"Acceso denegado al guardar conexiones en {AppSettingsFilePath}: {ex.Message}", "Error de permisos", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // Manejar cualquier otro tipo de error
                System.Windows.MessageBox.Show($"Ocurrió un error al guardar conexiones: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        // Establecer una conexión como predeterminada
        public static void SetDefaultConnection(string name)
        {
            var connections = LoadConnections();
            foreach (var connection in connections)
            {
                connection.IsDefault = connection.Name == name;
            }

            SaveConnections(connections);
        }
    }
}
