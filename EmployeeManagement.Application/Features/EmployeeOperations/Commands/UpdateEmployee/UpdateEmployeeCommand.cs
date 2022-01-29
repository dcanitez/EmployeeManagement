using AutoMapper;
using EmployeeManagement.Application.Contracts.Persistence.Repositories.Employees;
using EmployeeManagement.Application.Models.Employee;
using EmployeeManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.EmployeeOperations.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public UpdateEmployeeCommand(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        public EmployeeUpdateModel Model { get; set; }
        public int Id { get; set; }
        public async Task<bool> Handle()
        {
            var result = await employeeRepository.Get(Id);
            if (result is null)
                throw new InvalidOperationException($"Employee with Id={Id} could not found");
            else
                result = mapper.Map<Employee>(Model);
            return await employeeRepository.Update(result, Id) != null ? true : false;
        }
    }
}
