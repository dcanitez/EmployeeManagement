using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace EmployeeManagement.Infrastructure.Contracts.Persistence.Repositories.EntityConfigurations
{
    public class DepartmentTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //Seed Data for Departments Table
            builder.HasData(new List<Department>()
            {
                new Department { DepartmentId=1, DepartmentName="IT"},
                new Department { DepartmentId=2, DepartmentName="HR"},
                new Department { DepartmentId=3, DepartmentName="Payroll"},
                new Department { DepartmentId=4, DepartmentName="Admin"}
            });
        }
    }
}
