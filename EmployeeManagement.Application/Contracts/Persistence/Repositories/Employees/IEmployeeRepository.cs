using EmployeeManagement.Application.Contracts.Persistence.Repositories.Commons;
using EmployeeManagement.Domain.Entities;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Contracts.Persistence.Repositories.Employees
{
    public interface IEmployeeRepository : IRepositoryOperations<Employee, int>
    {
        Task<Employee> GetByEmail(string email);
    }
}
