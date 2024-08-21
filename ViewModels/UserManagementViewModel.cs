using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHEndevour.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SHEndevour.Views;
using Microsoft.EntityFrameworkCore;
using SHEndevour.Utilities;
using MessageBox = System.Windows.MessageBox;

namespace SHEndevour.ViewModels
{
    public partial class UserManagementViewModel : ObservableObject
    {
        // Propiedades que enlazarás en la vista
        [ObservableProperty]
        private ObservableCollection<UserModel> users;

        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private ObservableCollection<UserModel> filteredUsers;

        [ObservableProperty]
        private bool isPopupOpen; // Ahora es un bool en lugar de Visibility

        [ObservableProperty]
        private UserModel selectedUser;

        // Comandos
        public ICommand AddUserCommand { get; }
        public ICommand ViewUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand SearchCommand { get; }

        public UserManagementViewModel()
        {
            Users = new ObservableCollection<UserModel>();
            FilteredUsers = new ObservableCollection<UserModel>();
            IsPopupOpen = false;

            // Cargar los usuarios desde la base de datos
            LoadUsers();

            // Inicializa los comandos
            AddUserCommand = new RelayCommand(AddUser);
            ViewUserCommand = new RelayCommand(ViewUser);
            DeleteUserCommand = new RelayCommand(DeleteUser);
            SearchCommand = new RelayCommand(SearchUser);
        }

        private void LoadUsers()
        {
            using (var dbContext = new AppDbContext())
            {
                var usersFromDb = dbContext.Users
                                           .Include(u => u.Role) // Incluir el rol asociado
                                           .ToList();

                Users.Clear(); // Limpiar la colección actual

                foreach (var user in usersFromDb)
                {
                    Users.Add(user);
                }
            }
        }

        #region AddUsersRegion
        private void AddUser()
        {
            // Abrir el diálogo de agregar usuario
            var addUserDialog = new AddEditUserDialog();

            if (addUserDialog.ShowDialog() == true)
            {
                var newUser = addUserDialog.User;
                newUser.Password = PasswordHelper.HashPassword(newUser.Password); // Cifrar la contraseña

                using (var dbContext = new AppDbContext())
                {
                    dbContext.Users.Add(newUser);
                    dbContext.SaveChanges();
                }

                LoadUsers();
                MessageBox.Show("Usuario añadido con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion

        #region ViewUsersRegion
        private void ViewUser()
        {
            var selectedUser = Users.FirstOrDefault(u => u.IsSelected);

            if (selectedUser != null)
            {
                var editUserDialog = new AddEditUserDialog(selectedUser);
                var originalPassword = selectedUser.Password;

                if (editUserDialog.ShowDialog() == true)
                {
                    var updatedUser = editUserDialog.User;

                    // Solo cifrar si la contraseña ha cambiado
                    if (originalPassword != updatedUser.Password)
                    {
                        updatedUser.Password = PasswordHelper.HashPassword(updatedUser.Password);
                    }

                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Users.Update(updatedUser);
                        dbContext.SaveChanges();
                    }

                    LoadUsers();
                    MessageBox.Show("Usuario actualizado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para ver.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region DeleteUsersRegion
        private void DeleteUser()
        {
            var selectedUsers = Users.Where(u => u.IsSelected).ToList();

            if (selectedUsers.Any())
            {
                var result = MessageBox.Show($"¿Estás seguro de que deseas eliminar {selectedUsers.Count} usuario(s)?",
                                             "Confirmar eliminación",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using (var dbContext = new AppDbContext())
                    {
                        foreach (var user in selectedUsers)
                        {
                            dbContext.Users.Remove(user);
                        }
                        dbContext.SaveChanges();
                    }

                    LoadUsers();
                    MessageBox.Show("Usuario(s) eliminado(s) con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione al menos un usuario para eliminar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region SearchUsersRegion
        private void SearchUser()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredUsers.Clear();
                IsPopupOpen = false;
                return;
            }

            var filteredUsersList = Users
                .Where(u => u.Username.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                            u.FirstName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                            u.LastName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                            u.Email.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            FilteredUsers = new ObservableCollection<UserModel>(filteredUsersList);
            IsPopupOpen = FilteredUsers.Any(); // Mostrar el Popup solo si hay resultados

            // Asegurarse de que no haya un usuario seleccionado accidentalmente al escribir
            SelectedUser = null;
        }

        partial void OnSearchTextChanged(string value)
        {
            SelectedUser = null;
            SearchUser();
        }

        partial void OnSelectedUserChanged(UserModel user)
        {
            if (user != null)
            {
                var editUserDialog = new AddEditUserDialog(user);

                if (editUserDialog.ShowDialog() == true)
                {
                    // Solo cifrar si la contraseña ha cambiado
                    if (user.Password != PasswordHelper.HashPassword(user.Password))
                    {
                        user.Password = PasswordHelper.HashPassword(user.Password);
                    }

                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Users.Update(user);
                        dbContext.SaveChanges();
                    }

                    LoadUsers();
                    MessageBox.Show("Usuario actualizado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                SelectedUser = null;
                IsPopupOpen = false;
            }
        }
        #endregion
    }
}
