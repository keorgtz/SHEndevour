using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SHEndevour.Models;

namespace SHEndevour.Utilities
{
    public class AppDbContext : DbContext
    {
        // Agregamos los Modelos para que se Generen las Tablas
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<RoomModel> Room { get; set; }
        public DbSet<RoomTypeModel> RoomType { get; set; }

        //public DbSet<ProductModel> Products { get; set; }  ---------  // Si tienes más modelos, añádelos aquí

        // Instancia de ConnectionSettings
        private readonly DbConectionSettings _connectionSettings = new DbConectionSettings();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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


        }

        public override int SaveChanges()
        {
            // Identifica las entidades que heredan de AuditableEntity
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
