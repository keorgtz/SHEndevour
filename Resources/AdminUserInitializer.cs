using System.Linq;
using SHEndevour.Utilities; // Asegúrate de importar el namespace donde está PasswordHelper
using SHEndevour.Models;

public class AdminUserInitializer
{
    public static void EnsureAdminUser()
    {
        using (var dbContext = new AppDbContext())
        {
            // Verifica si ya existe un usuario con el rol de Admin
            var adminRole = dbContext.Roles.FirstOrDefault(r => r.Name == "Admin");
            if (adminRole == null)
            {
                // Si el rol de Admin no existe, lo crea
                adminRole = new RoleModel { Name = "Admin", Level = 1 };
                dbContext.Roles.Add(adminRole);
                dbContext.SaveChanges();
            }

            var adminUser = dbContext.Users.FirstOrDefault(u => u.RoleId == adminRole.Id);
            if (adminUser == null)
            {
                // Si no existe un usuario administrador, lo crea
                var hashedPassword = PasswordHelper.HashPassword("admin"); // Cambia la contraseña según sea necesario

                adminUser = new UserModel
                {
                    Username = "admin",
                    Password = hashedPassword,
                    FirstName = "Ryou",
                    LastName = "Sakura",
                    Email = "admin@gmail.com",
                    PhoneNumber = "1234567890",
                    RoleId = adminRole.Id,
                    IsSelected = false // Según tu lógica, configura esto como sea necesario
                };

                dbContext.Users.Add(adminUser);
                dbContext.SaveChanges();
            }
        }
    }
}
