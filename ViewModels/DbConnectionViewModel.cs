using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHEndevour.Utilities;
using SHEndevour.Views.DatabaseView;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace SHEndevour.ViewModels
{
    public class DbConnectionViewModel : ObservableObject
    {
        // Property that contains the list of connections
        public ObservableCollection<DbConnectionSettings> Connections { get; set; }


        // Property for the selected connection
        private DbConnectionSettings _selectedConnection;
        public DbConnectionSettings SelectedConnection
        {
            get => _selectedConnection;
            set
            {
                if (SetProperty(ref _selectedConnection, value))
                {
                    // Update command availability and notify changes
                    
                    DeleteCommand.NotifyCanExecuteChanged();
                    SetDefaultCommand.NotifyCanExecuteChanged();

                    // Debug message
                    Console.WriteLine($"SelectedConnection changed: {_selectedConnection?.Name ?? "None"}");
                }
            }
        }

        // Constructor to load connections from configuration file
        public DbConnectionViewModel()
        {
            Connections = new ObservableCollection<DbConnectionSettings>(DbConnectionSettings.LoadConnections());

            // Initialize the commands here
            DeleteCommand = new RelayCommand(DeleteConnection, CanEditOrDelete);
            SetDefaultCommand = new RelayCommand(SetDefaultConnection, CanEditOrDelete);

            // Inicializar el comando de creación de base de datos
            CreateDatabaseCommand = new RelayCommand(CreateDatabase);
        }

        // Commands for operations (Add, Delete, Set Default)
        public IRelayCommand AddCommand => new RelayCommand(AddConnection);
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SetDefaultCommand { get; set; }

        // Command to create the database
        public IRelayCommand CreateDatabaseCommand { get; }


        // Method to add a new connection
        private void AddConnection()
        {
            var dialog = new DatabaseConnectionDialog();

            // Show dialog modally and check if a new connection is added
            if (dialog.ShowDialog() == true)
            {
                var newConnection = dialog.ConnectionSettings;

                // Verify that the name is not duplicated to avoid errors
                if (Connections.Any(c => c.Name == newConnection.Name))
                {
                    MessageBox.Show($"A connection with the name '{newConnection.Name}' already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Connections.Add(newConnection);
                DbConnectionSettings.SaveConnections(Connections.ToList());

                // Debug message for verifying the addition of a new connection
                Console.WriteLine($"Added new connection: {newConnection.Name}");
            }
        }

        private void CreateDatabase()
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    context.Database.EnsureCreated();
                    MessageBox.Show("Base de datos creada o ya existente.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            
        }


        // Method to delete the selected connection
        private void DeleteConnection()
        {
            if (SelectedConnection != null)
            {
                var result = MessageBox.Show($"¿Está seguro que desea eliminar la conexión '{SelectedConnection?.Name}'?",
                    "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    Connections.Remove(SelectedConnection);
                    DbConnectionSettings.SaveConnections(Connections.ToList());

                    // Mensaje de depuración para verificar la eliminación
                    Console.WriteLine($"Deleted connection: {SelectedConnection?.Name}");

                    SelectedConnection = null; // Limpiar la selección después de eliminar

                    // Notificar cambios en la lista de conexiones
                    OnPropertyChanged(nameof(Connections));
                }
            }
            else
            {
                MessageBox.Show("No hay ninguna conexión seleccionada para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Method to set the selected connection as default
        private void SetDefaultConnection()
        {
            if (SelectedConnection != null)
            {
                DbConnectionSettings.SetDefaultConnection(SelectedConnection.Name);

                // Refresh the state of all connections to reflect the default connection
                foreach (var conn in Connections)
                {
                    conn.IsDefault = conn.Name == SelectedConnection.Name;
                }

                // Debug message for verifying the default connection
                Console.WriteLine($"Set connection as default: {SelectedConnection.Name}");

                OnPropertyChanged(nameof(Connections));
            }
        }

        // Method to determine if the selected connection can be edited or deleted
        private bool CanEditOrDelete()
        {
            // A connection must be selected to enable editing or deleting
            return SelectedConnection != null;
        }
    }
}
