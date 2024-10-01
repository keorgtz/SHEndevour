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
using Microsoft.VisualBasic.ApplicationServices;
using SHEndevour.Repositories.Reports;
using SHEndevour.Views.Reports.Users;
using DevExpress.XtraReports.UI;
using DevExpress.Xpf.Printing;

namespace SHEndevour.ViewModels
{
    public partial class UserManagementViewModel : ObservableObject
    {
        // Propiedades que enlazarás en la vista
        [ObservableProperty]
        private ObservableCollection<UserModel> users;


        [ObservableProperty]
        private UserModel selectedUser;


        // Comandos
        public ICommand AddUserCommand { get; }
        public ICommand ViewUserCommand { get; }
        public ICommand DeleteUserCommand { get; }


        public UserManagementViewModel()
        {
            Users = new ObservableCollection<UserModel>();


            // Cargar los usuarios desde la base de datos
            LoadUsers();

            // Inicializa los comandos
            AddUserCommand = new RelayCommand(AddUser);
            ViewUserCommand = new RelayCommand(ViewUser, CanEditOrDelete);
            DeleteUserCommand = new RelayCommand(DeleteUser, CanEditOrDelete);

        }

        private void LoadUsers()
        {
            using (var dbContext = new AppDbContext())
            {
                var usersFromDb = dbContext.Users
                                           .Include(u => u.Role) // Incluir el rol asociado
                                           .ToList();

                Users.Clear(); // Limpiar la colección actual\

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

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

        #region ViewUsersRegion
        private void ViewUser()
        {
            if (SelectedUser != null)
            {
                var editUserDialog = new AddEditUserDialog(SelectedUser);
                var originalPassword = SelectedUser.Password;

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
                else
                {
                    LoadUsers();
                    MessageBox.Show("Operación Cancelada", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para ver.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion


        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

        #region DeleteUsersRegion
        private void DeleteUser()
        {
            if (SelectedUser != null)
            {
                if (SelectedUser.Username != App.CurrentUser.Username)
                {
                    var result = MessageBox.Show($"¿Estás seguro de que deseas eliminar el usuario '{SelectedUser.Username}'?",
                                             "Confirmar eliminación",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        using (var dbContext = new AppDbContext())
                        {
                            dbContext.Users.Remove(SelectedUser);
                            dbContext.SaveChanges();
                        }

                        LoadUsers();
                        MessageBox.Show("Usuario eliminado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show($"No Puedes Eliminar el Usuario '{SelectedUser.Username}' \nDebes Eliminarlo desde Otra Cuenta",
                                             "Advertencia",
                                             MessageBoxButton.OK,
                                             MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion


        private bool CanEditOrDelete()
        {
            return SelectedUser != null;
        }

        partial void OnSelectedUserChanged(UserModel value)
        {

            (ViewUserCommand as RelayCommand)?.NotifyCanExecuteChanged();
            (DeleteUserCommand as RelayCommand)?.NotifyCanExecuteChanged();

        }
       

        
    }
}
