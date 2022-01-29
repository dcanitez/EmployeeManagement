using AutoMapper;
using EmployeeManagement.Application.Contracts.Persistence.Repositories.Employees;
using EmployeeManagement.Application.Models.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.EmployeeOperations.Queries.GetEmployees
{
    public class GetEmployeesQuery
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public GetEmployeesQuery(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeDetailsModel>> Handle()
        {
            var result = await employeeRepository.GetAll();
            IEnumerable<EmployeeDetailsModel> model = mapper.Map<IEnumerable<EmployeeDetailsModel>>(result);
            return model;
        }
    }
}
