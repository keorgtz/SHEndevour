using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using SHEndevour.Models;

namespace SHEndevour.Utilities
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura la cadena de conexión
            optionsBuilder.UseSqlServer(@"Server=KEVINPC\SQLEXPRESS;Database=endevour_db;User Id=sa;Password=InfoHotel01;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
            .HasIndex(u => u.Username)
            .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
