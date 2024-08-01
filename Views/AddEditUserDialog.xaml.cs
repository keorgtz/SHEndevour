using System;
using System.Linq;
using System.Windows;
using SHEndevour.Models;
using SHEndevour.Utilities;

namespace SHEndevour.Views
{
    public partial class AddEditUserDialog : Window
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        private UserModel _user;
        private bool IsEdit { get; set; }
        private readonly AppDbContext _context;

        // Constructor para crear un nuevo usuario
        public AddEditUserDialog()
        {
            InitializeComponent();
            _context = new AppDbContext();
            IsEdit = false;
        }

        // Constructor para editar un usuario existente
        public AddEditUserDialog(UserModel user) : this()
        {
            _user = user;
            IsEdit = true;

            // Rellena los campos con los datos del usuario seleccionado
            UsernameTextBox.Text = user.Username;
            PasswordBox.Password = ""; // No mostramos la contraseña
            RoleTextBox.Text = user.Role;
            FirstNameTextBox.Text = user.FirstName;
            LastNameTextBox.Text = user.LastName;
            EmailTextBox.Text = user.Email;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Validaciones de los campos del formulario
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(RoleTextBox.Text) ||
                string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                !IsValidEmail(EmailTextBox.Text))
            {
                MessageBox.Show("Todos los Campos deben ser llenados de manera correcta.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Verifica que el nombre de usuario no esté en uso por otro usuario si es una edición
            if (IsEdit && _context.Users.Any(u => u.Username == UsernameTextBox.Text && u.Id != _user.Id))
            {
                MessageBox.Show("Nombre de Usuario ya Existente.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            } else if (!IsEdit && _context.Users.Any(u => u.Username == UsernameTextBox.Text))
            {
                MessageBox.Show("Nombre de Usuario ya Existente.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            // Obtén los datos del formulario
            Username = UsernameTextBox.Text;
            Role = RoleTextBox.Text;
            FirstName = FirstNameTextBox.Text;
            LastName = LastNameTextBox.Text;
            Email = EmailTextBox.Text;

            if (IsEdit)
            {
                // Si la contraseña se deja vacía, mantén la contraseña actual
                if (string.IsNullOrWhiteSpace(PasswordBox.Password))
                {
                    Password = _user.Password;
                }
                else
                {
                    // Si se proporciona una nueva contraseña, hasheala
                    var salt = PasswordHelper.GenerateSalt();
                    Password = PasswordHelper.HashPassword(PasswordBox.Password, salt);
                }
            }
            else
            {
                // Si es una creación, hashea la nueva contraseña
                var salt = PasswordHelper.GenerateSalt();
                Password = PasswordHelper.HashPassword(PasswordBox.Password, salt);
            }

            // Indica que el diálogo se cerró con éxito
            DialogResult = true;
            Close();
        }

        private bool IsValidEmail(string email)
        {
            // Validación básica de correo electrónico usando una expresión regular
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
