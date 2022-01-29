using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Contracts.Persistence.Repositories.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Contracts.Persistence.Repositories.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            //Seed Data for departments and employees tables
            modelBuilder.ApplyConfiguration(new DepartmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeTypeConfiguration());


        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
