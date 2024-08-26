using DevExpress.XtraRichEdit.Layout;
using SHEndevour.Models;
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
using MaterialDesignThemes.Wpf;
using MaterialDesignExtensions.Controls;
using System.Text.RegularExpressions;
using MessageBox = System.Windows.MessageBox;


namespace SHEndevour.Views
{
    public partial class AddEditUserDialog : Window
    {
        public UserModel User { get; private set; }

        public AddEditUserDialog(UserModel user = null)
        {
            InitializeComponent();
            LoadRoles();

            if (user != null)
            {
                User = user;
                PopulateFields(); // Poblar los campos si se está editando un usuario
                Title = "Editar Usuario";
                AddEditSubtitle.Text = "Edicion de Usuario";
                user.IsSelected = false;
            }
            else
            {
                User = new UserModel();
                Title = "Añadir Usuario";
                AddEditSubtitle.Text = "Agregar un Nuevo Usuario";
            }

            DataContext = User;
            ValidateFields(); // Inicializar la validación de campos

        }

        

        private void PhoneTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Permitir solo entrada numérica
            e.Handled = !IsTextNumeric(e.Text);
        }

        private bool IsTextNumeric(string text)
        {
            return text.All(char.IsDigit);
        }

        private void LoadRoles()
        {
            using (var context = new AppDbContext())
            {
                var roles = context.Roles.ToList();
                RoleComboBox.ItemsSource = roles;
                RoleComboBox.DisplayMemberPath = "Name"; // Nombre del rol a mostrar
                RoleComboBox.SelectedValuePath = "Id";   // El valor seleccionado será el Id del rol
            }
        }

        private void PopulateFields()
        {
            UsernameTextBox.Text = User.Username;
            PassBox.Password = User.Password;
            FirstNameTextBox.Text = User.FirstName;
            LastNameTextBox.Text = User.LastName;
            EmailTextBox.Text = User.Email;
            PhoneTextBox.Text = User.PhoneNumber;
            RoleComboBox.SelectedValue = User.RoleId; // Seleccionar el rol actual del usuario
        }

        private void OnAcceptClick(object sender, RoutedEventArgs e)
        {
            if (!IsValidEmail(EmailTextBox.Text))
            {
                MessageBox.Show("El correo electrónico no es válido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (PhoneTextBox.Text.Length != 10 || !IsTextNumeric(PhoneTextBox.Text))
            {
                MessageBox.Show("El número de teléfono debe ser de 10 dígitos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Solo validar duplicidad de nombre de usuario si ha sido modificado
            if (User.Username != UsernameTextBox.Text && IsUsernameDuplicate(UsernameTextBox.Text))
            {
                MessageBox.Show("El nombre de usuario ya existe.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Actualizar solo los valores que han sido modificados
            if (User.Username != UsernameTextBox.Text)
            {
                User.Username = UsernameTextBox.Text;
            }

            if (User.Password != PassBox.Password)
            {
                User.Password = PassBox.Password;
            }

            if (User.FirstName != FirstNameTextBox.Text)
            {
                User.FirstName = FirstNameTextBox.Text;
            }

            if (User.LastName != LastNameTextBox.Text)
            {
                User.LastName = LastNameTextBox.Text;
            }

            if (User.Email != EmailTextBox.Text)
            {
                User.Email = EmailTextBox.Text;
            }

            if (User.PhoneNumber != PhoneTextBox.Text)
            {
                User.PhoneNumber = PhoneTextBox.Text; // Almacenar el teléfono como cadena
            }

            if (User.RoleId != (int)RoleComboBox.SelectedValue)
            {
                User.RoleId = (int)RoleComboBox.SelectedValue; // Guarda el Id del rol seleccionado
            }

            
            DialogResult = true;
            User.IsSelected = false;
            Close();
            User.IsSelected = false;
        }


        private void ValidateFields()
        {
            bool isFormValid = !string.IsNullOrWhiteSpace(UsernameTextBox.Text) &&
                               !string.IsNullOrWhiteSpace(PassBox.Password) &&
                               !string.IsNullOrWhiteSpace(FirstNameTextBox.Text) &&
                               !string.IsNullOrWhiteSpace(LastNameTextBox.Text) &&
                               !string.IsNullOrWhiteSpace(EmailTextBox.Text) &&
                               RoleComboBox.SelectedValue != null &&
                               !string.IsNullOrWhiteSpace(PhoneTextBox.Text) &&
                               PhoneTextBox.Text.Length == 10; // Asegurarse de que el teléfono tenga 10 dígitos

            // Validar que el correo tenga un formato válido
            if (!IsValidEmail(EmailTextBox.Text))
            {
                isFormValid = false;
            }

            AddButton.IsEnabled = isFormValid;
            User.IsSelected = false;
            
        }

        private void OnTextChanged(object sender, RoutedEventArgs e)
        {
            ValidateFields();
        }

        private void OnRoleSelectionChanged(object sender, RoutedEventArgs e)
        {
            ValidateFields();
        }

        private bool IsUsernameDuplicate(string username)
        {
            using (var context = new AppDbContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        private bool IsValidEmail(string email)
        {
            // Expresión regular para validar correos electrónicos
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
