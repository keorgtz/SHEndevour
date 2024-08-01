using System.Windows;
using System.Windows.Controls;
using SHEndevour.Models;
using SHEndevour.Utilities;
using SHEndevour.Views;

namespace SHEndevour.Views
{
    public partial class UsersView : UserControl
    {
        private readonly AppDbContext _context;

        public UsersView()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadUsers();
        }

        private void LoadUsers()
        {
            UsersDataGrid.ItemsSource = _context.Users.ToList();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddEditUserDialog();
            if (dialog.ShowDialog() == true)
            {
                // Handle adding user
                var user = new UserModel
                {
                    Username = dialog.Username,
                    Password = dialog.Password,
                    Role = dialog.Role,
                    FirstName = dialog.FirstName,
                    LastName = dialog.LastName,
                    Email = dialog.Email
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                LoadUsers();
            }
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is UserModel selectedUser)
            {
                var dialog = new AddEditUserDialog(selectedUser);
                if (dialog.ShowDialog() == true)
                {
                    // Handle editing user
                    selectedUser.Username = dialog.Username;
                    selectedUser.Password = dialog.Password;
                    selectedUser.Role = dialog.Role;
                    selectedUser.FirstName = dialog.FirstName;
                    selectedUser.LastName = dialog.LastName;
                    selectedUser.Email = dialog.Email;

                    _context.Users.Update(selectedUser);
                    _context.SaveChanges();
                    LoadUsers();
                }
            }
            else
            {
                MessageBox.Show("Please select a user to edit.");
            }
        }

        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is UserModel selectedUser)
            {
                var result = MessageBox.Show($"Are you sure you want to delete user {selectedUser.Username}?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _context.Users.Remove(selectedUser);
                    _context.SaveChanges();
                    LoadUsers();
                }
            }
            else
            {
                MessageBox.Show("Please select a user to remove.");
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is UserModel user)
            {
                var result = MessageBox.Show($"Are you sure you want to delete user {user.Username}?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    LoadUsers();
                }
            }
        }
    }
}
