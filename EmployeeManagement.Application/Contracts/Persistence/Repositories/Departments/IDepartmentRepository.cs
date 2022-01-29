using EmployeeManagement.Application.Contracts.Persistence.Repositories.Commons;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Contracts.Persistence.Repositories.Departments
{
    public interface IDepartmentRepository : IRepositoryOperations<Department, int>
    {

    }
}
