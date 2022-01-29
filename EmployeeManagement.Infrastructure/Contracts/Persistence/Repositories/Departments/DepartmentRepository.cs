using EmployeeManagement.Application.Contracts.Persistence.Repositories.Departments;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Contracts.Persistence.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Contracts.Persistence.Repositories.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext context;

        public DepartmentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Department> Delete(int id)
        {
            var result = await context.Departments
                .SingleOrDefaultAsync(d => d.DepartmentId == id);
            if (result is not null)
            {
                context.Departments.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Department> Get(int id)
        {
            return await context.Departments
                .SingleOrDefaultAsync(d => d.DepartmentId == id);
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await context.Departments.ToListAsync();
        }

        public async Task<Department> Insert(Department entity)
        {
            var result = await context.Departments.AddAsync(entity);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Department> Update(Department entity, int id)
        {
            var result = await context.Departments
                .SingleOrDefaultAsync(d => d.DepartmentId == id);
            if (result is not null)
            {
                result.DepartmentName = entity.DepartmentName != default ? entity.DepartmentName : result.DepartmentName;

                await context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
