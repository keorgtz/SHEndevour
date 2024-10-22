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
    public class RoleTemplatesViewModel : ObservableObject
    {
        private readonly AppDbContext _context;

        public ObservableCollection<RoleModel> Roles { get; set; }
        public ObservableCollection<RolePermissionTemplate> ControlPermissions { get; set; }

        private RoleModel? _selectedRole;
        public RoleModel? SelectedRole
        {
            get => _selectedRole;
            set
            {
                SetProperty(ref _selectedRole, value);
                LoadPermissions();
            }
        }

        public IRelayCommand SavePermissionsCommand { get; }

        public RoleTemplatesViewModel()
        {
            _context = new AppDbContext();
            Roles = new ObservableCollection<RoleModel>(_context.Roles.ToList());
            ControlPermissions = new ObservableCollection<RolePermissionTemplate>();

            SavePermissionsCommand = new RelayCommand(SavePermissions);
        }

        private void LoadPermissions()
        {
            if (SelectedRole == null) return;

            ControlPermissions.Clear();

            // Usar reflexión para encontrar todas las vistas y controles.
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
                    // Buscar si ya existe un permiso en la base de datos
                    var permission = _context.RolePermissionTable
                        .FirstOrDefault(p => p.RoleId == SelectedRole.Id &&
                                             p.ViewName == view.Name &&
                                             p.ControlName == control.Name);

                    // Si no existe, crear un permiso por defecto
                    ControlPermissions.Add(permission ?? new RolePermissionTemplate
                    {
                        RoleId = SelectedRole.Id,
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
                var existing = _context.RolePermissionTable
                    .FirstOrDefault(p => p.RoleId == permission.RoleId &&
                                         p.ViewName == permission.ViewName &&
                                         p.ControlName == permission.ControlName);

                if (existing != null)
                {
                    existing.IsVisible = permission.IsVisible;
                    existing.IsEnabled = permission.IsEnabled;
                }
                else
                {
                    _context.RolePermissionTable.Add(permission);
                }
            }

            _context.SaveChanges();
            MessageBox.Show("Permisos guardados exitosamente.");
        }
    }
}
