using EmployeeManagement.Application.Contracts.Persistence.Repositories.Employees;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.EmployeeOperations.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand
    {
        private readonly IEmployeeRepository employeeRepository;

        public DeleteEmployeeCommand(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public int Id { get; set; }
        public async Task<bool> Handle()
        {
            var result = await employeeRepository.Get(Id);
            if (result is null)
                throw new InvalidOperationException($"Employee with Id={Id} does not exist");
            else
                return await employeeRepository.Delete(Id) != null ? true : false;

        }
    }
}
