using AutoMapper;
using EmployeeManagement.Application.Contracts.Persistence.Repositories.Employees;
using EmployeeManagement.Application.Models.Employee;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.EmployeeOperations.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQuery
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public GetEmployeeDetailsQuery(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        public int Id { get; set; }
        public async Task<EmployeeDetailsModel> Handle()
        {
            var result = await employeeRepository.Get(Id);
            if (result is null)
                throw new InvalidOperationException($"Employee with Id={Id} could not be found");
            EmployeeDetailsModel model = mapper.Map<EmployeeDetailsModel>(result);
            return model;
        }
    }
}
