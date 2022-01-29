using EmployeeManagement.Application.Contracts.Persistence.Repositories.Employees;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Contracts.Persistence.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Contracts.Persistence.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public EmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Employee> Delete(int id)
        {
            var result = await context.Employees
                .SingleOrDefaultAsync(e => e.EmployeeId == id);
            if (result is not null)
            {
                context.Employees.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Employee> Get(int id)
        {
            return await context.Employees
                .SingleOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await context.Employees.Include(d => d.Department).ToListAsync();
        }

        public async Task<Employee> GetByEmail(string email)
        {
            return await context.Employees
                .SingleOrDefaultAsync(e => e.Email.ToLower() == email.ToLower());
        }

        public async Task<Employee> Insert(Employee entity)
        {
            var result = await context.Employees.AddAsync(entity);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> Update(Employee entity, int id)
        {
            var result = await Get(id);
            result.FirstName = entity.FirstName != default ? entity.FirstName : result.FirstName;
            result.LastName = entity.LastName != default ? entity.LastName : result.LastName;
            result.DateOfBirth = entity.DateOfBirth != default ? entity.DateOfBirth : result.DateOfBirth;
            result.Gender = entity.Gender != default ? entity.Gender : result.Gender;
            result.DepartmentId = entity.DepartmentId != default ? entity.DepartmentId : result.DepartmentId;
            result.PhotoPath = entity.PhotoPath != default ? entity.PhotoPath : result.PhotoPath;

            await context.SaveChangesAsync();
            return result;
        }
    }
}
