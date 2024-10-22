using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using SHEndevour.Models;
using SHEndevour.Utilities;
using Control = System.Windows.Controls.Control;

namespace SHEndevour.Services
{
    public class PermissionService
    {
        private readonly AppDbContext _context;

        public PermissionService()
        {
            _context = new AppDbContext();
        }

        /// <summary>
        /// Aplica los permisos del usuario actual a los controles de cualquier contenedor.
        /// </summary>
        /// <param name="container">El contenedor (Window, Page, UserControl) donde se aplicarán los permisos.</param>
        public void ApplyPermissions(FrameworkElement container)
        {
            if (App.CurrentUser == null) return;  // Verifica si hay un usuario autenticado.

            // Obtener los permisos del usuario actual
            var userPermissions = _context.ControlPermissionTable
                                          .Where(p => p.UserId == App.CurrentUser.Id)
                                          .ToList();

            // Aplicar los permisos a cada control del contenedor
            foreach (var permission in userPermissions)
            {
                var control = container.FindName(permission.ControlName) as Control;
                if (control != null)
                {
                    control.Visibility = permission.IsVisible ? Visibility.Visible : Visibility.Collapsed;
                    control.IsEnabled = permission.IsEnabled;
                }
            }
        }
    }
}
