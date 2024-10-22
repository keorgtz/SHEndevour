using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHEndevour.Models;
using SHEndevour.Models.ControlRestriction;
using SHEndevour.Utilities;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Control = System.Windows.Controls.Control;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace SHEndevour.ViewModels.ControlRestrictionVM
{
    public class PermissionsDashboardViewModel : ObservableObject
    {
        private readonly AppDbContext _context;

        public ObservableCollection<UserModel> Users { get; set; }
        public ObservableCollection<ControlPermissionModel> ControlPermissions { get; set; }

        private UserModel? _selectedUser;
        public UserModel? SelectedUser
        {
            get => _selectedUser;
            set
            {
                SetProperty(ref _selectedUser, value);
                LoadPermissions();
            }
        }

        public IRelayCommand SavePermissionsCommand { get; }

        public PermissionsDashboardViewModel()
        {
            _context = new AppDbContext();
            Users = new ObservableCollection<UserModel>(_context.Users.ToList());
            ControlPermissions = new ObservableCollection<ControlPermissionModel>();

            SavePermissionsCommand = new RelayCommand(SavePermissions);
        }

        private void LoadPermissions()
        {
            if (SelectedUser == null) return;

            ControlPermissions.Clear();

            // Recorrer todas las ventanas y UserControls usando Reflection.
            var views = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .Where(t => typeof(Window).IsAssignableFrom(t) ||
                                            typeof(UserControl).IsAssignableFrom(t));

            foreach (var view in views)
            {
                var controls = view.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                   .Where(f => typeof(Control).IsAssignableFrom(f.FieldType));

                foreach (var control in controls)
                {
                    var permission = _context.ControlPermissionTable
                        .FirstOrDefault(p => p.UserId == SelectedUser.Id &&
                                             p.ViewName == view.Name &&
                                             p.ControlName == control.Name);

                    ControlPermissions.Add(permission ?? new ControlPermissionModel
                    {
                        UserId = SelectedUser.Id,
                        ViewName = view.Name,
                        ControlName = control.Name,
                        IsVisible = true,
                        IsEnabled = true
                    });
                }
            }
        }

        private void SavePermissions()
        {
            foreach (var permission in ControlPermissions)
            {
                var existing = _context.ControlPermissionTable
                    .FirstOrDefault(p => p.UserId == permission.UserId &&
                                         p.ViewName == permission.ViewName &&
                                         p.ControlName == permission.ControlName);

                if (existing != null)
                {
                    existing.IsVisible = permission.IsVisible;
                    existing.IsEnabled = permission.IsEnabled;
                }
                else
                {
                    _context.ControlPermissionTable.Add(permission);
                }
            }

            _context.SaveChanges();
            MessageBox.Show("Permisos guardados exitosamente.");
        }


        public void ApplyUserPermissions(Window window)
        {
            if (App.CurrentUser == null) return;

            // Obtiene los permisos del usuario desde la base de datos
            var userPermissions = _context.ControlPermissionTable
                                          .Where(p => p.UserId == App.CurrentUser.Id)
                                          .ToList();

            // Aplica los permisos a cada control correspondiente
            foreach (var permission in userPermissions)
            {
                var control = window.FindName(permission.ControlName) as UIElement;
                if (control != null)
                {
                    // Cambia visibilidad según el permiso
                    control.Visibility = permission.IsVisible ? Visibility.Visible : Visibility.Collapsed;

                    // Si el control es habilitable, cambia su estado
                    if (control is Control ctrl)
                    {
                        ctrl.IsEnabled = permission.IsEnabled;
                    }
                }
            }
        }


    }
}
