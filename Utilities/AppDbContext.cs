using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SHEndevour.Models;
using SHEndevour.Models.License;

namespace SHEndevour.Utilities
{
    public class AppDbContext : DbContext
    {
        // Agregamos los Modelos para que se Generen las Tablas

        // = = = = = = = = = = = = =  Usuarios  = = = = = = = = = = = = = = = = = = = 
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  

        // = = = = = = = = = = = = =  Cuartos  = = = = = = = = = = = = = = = = = = = = 
        public DbSet<RoomModel> RoomTable { get; set; }
        public DbSet<RoomTypeModel> RoomTypeTable { get; set; }
        public DbSet<RoomMaintenanceModel> RoomMaintenanceTable { get; set; }
        public DbSet<MaintenanceHistoryModel> MaintenanceHistoryTable { get; set; }

        // = = = = = = = = = = = = =  LicenseModel  = = = = = = = = = = = = = = = = = = 
        public DbSet<LicenseModel> LicenseTable { get; set; }

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 

        // = = = = = = = = = = = = =  Segmentos y Origen  = = = = = = = = = = = = = = = =

        public DbSet<SegmentModel> SegmentTable { get; set; }
        public DbSet<GeoOriginModel> GeoOriginTable { get; set; }

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 



        //public DbSet<ProductModel> Products { get; set; }  // Si tienes más modelos, añádelos aquí

        // Instancia para la configuración de conexiones
        private readonly DbConnectionSettings _connectionSettings;

        public AppDbContext()
        {
            // Cargar la configuración de conexiones desde el archivo .config
            var allConnections = DbConnectionSettings.LoadConnections();
            _connectionSettings = allConnections.FirstOrDefault(c => c.IsDefault); // Usar la conexión por defecto
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionSettings == null)
            {
                throw new InvalidOperationException("No se ha definido una conexión por defecto.");
            }

            // Configurar la cadena de conexión predeterminada
            optionsBuilder.UseSqlServer(_connectionSettings.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración inicial de los roles
            modelBuilder.Entity<RoleModel>().HasData(
                new RoleModel { Id = 1, Name = "Admin", Level = 1 },
                new RoleModel { Id = 2, Name = "Manager", Level = 2 },
                new RoleModel { Id = 3, Name = "Receptionist", Level = 3 },
                new RoleModel { Id = 4, Name = "Guest", Level = 4 },
                new RoleModel { Id = 5, Name = "User", Level = 5 }
            );

            modelBuilder.Entity<RoomModel>()
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public override int SaveChanges()
        {
            // Identificar las entidades que heredan de AuditableEntity
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is AuditableEntity &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                    ((AuditableEntity)entityEntry.Entity).CreatedBy = App.CurrentUser?.Id ?? 0; // Usa 0 si no hay usuario autenticado
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    ((AuditableEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;
                    ((AuditableEntity)entityEntry.Entity).UpdatedBy = App.CurrentUser?.Id ?? 0;
                }
            }

            return base.SaveChanges();
        }
    }
}
