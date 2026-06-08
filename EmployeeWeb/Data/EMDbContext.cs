using System.Reflection.Emit;
using EmployeeWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWeb.Data
{
    public class EMDbContext(DbContextOptions<EMDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                AdminId = 1,
                Username = "admin",
                Password = "admin123",
                Email = "admin@ferotech.bd"
            });
        }
    }
}