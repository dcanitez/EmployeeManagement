using AutoMapper;
using EmployeeManagement.Application.Contracts.Persistence.Repositories.Employees;
using EmployeeManagement.Application.Models.Employee;
using EmployeeManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.EmployeeOperations.Commands.CreateEmployee
{
    public class CreateEmployeeCommand
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public CreateEmployeeCommand(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        public EmployeeCreateModel Model { get; set; }
        public async Task<bool> Handle()
        {
            var employee = await employeeRepository.GetByEmail(Model.Email);
            if (employee is not null)
                throw new InvalidOperationException("Employee with same email address is already existed.");
            else
                employee = mapper.Map<Employee>(Model);
            if (await employeeRepository.Insert(employee) != null)
                return true;
            else
                return false;
        }

    }
}
