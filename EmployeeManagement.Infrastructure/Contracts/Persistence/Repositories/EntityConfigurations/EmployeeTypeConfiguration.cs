using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EmployeeManagement.Infrastructure.Contracts.Persistence.Repositories.EntityConfigurations
{
    public class EmployeeTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //Seed Data for Employees Table
            builder.HasData(
                new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@mail.com", DateOfBirth = new DateTime(1989, 4, 17), Gender = Gender.Male, DepartmentId = 1, PhotoPath = "images/john.png" },
                new Employee { EmployeeId = 2, FirstName = "Mary", LastName = "Jane", Email = "maryjane@mail.com", DateOfBirth = new DateTime(1991, 5, 30), Gender = Gender.Female, DepartmentId = 2, PhotoPath = "images/mary.png" },
                new Employee { EmployeeId = 3, FirstName = "Gary", LastName = "Hasting", Email = "garyhasting@mail.com", DateOfBirth = new DateTime(1988, 11, 27), Gender = Gender.Male, DepartmentId = 3, PhotoPath = "images/gary.png" },
                new Employee { EmployeeId = 4, FirstName = "Rachel", LastName = "Someone", Email = "rachelsomeone@mail.com", DateOfBirth = new DateTime(1993, 12, 6), Gender = Gender.Female, DepartmentId = 2, PhotoPath = "images/rachel.png" }
                );
        }
    }
}
