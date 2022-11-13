using Microsoft.EntityFrameworkCore;
using TryBackGroundService.Entities;

namespace TryBackGroundService.Context
{
    public class BaseDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BackGroundService;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "Backend Developer" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
