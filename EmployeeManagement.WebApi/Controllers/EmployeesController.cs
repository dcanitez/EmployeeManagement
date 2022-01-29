using AutoMapper;
using EmployeeManagement.Application.Contracts.Persistence.Repositories.Employees;
using EmployeeManagement.Application.Features.EmployeeOperations.Commands.CreateEmployee;
using EmployeeManagement.Application.Features.EmployeeOperations.Commands.DeleteEmployee;
using EmployeeManagement.Application.Features.EmployeeOperations.Commands.UpdateEmployee;
using EmployeeManagement.Application.Features.EmployeeOperations.Queries.GetEmployeeDetails;
using EmployeeManagement.Application.Features.EmployeeOperations.Queries.GetEmployees;
using EmployeeManagement.Application.Models.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                GetEmployeesQuery query = new GetEmployeesQuery(employeeRepository, mapper);
                return Ok(await query.Handle());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeDetailsModel>> Get(int id)
        {
            try
            {
                GetEmployeeDetailsQuery query = new GetEmployeeDetailsQuery(employeeRepository, mapper);
                query.Id = id;
                return Ok(await query.Handle());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(EmployeeCreateModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CreateEmployeeCommand command = new CreateEmployeeCommand(employeeRepository, mapper);
                    command.Model = model;
                    return await command.Handle() == true ? Ok() : BadRequest("Error creating employee");
                }
                return BadRequest("Please check the fields");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, EmployeeUpdateModel model)
        {
            try
            {
                UpdateEmployeeCommand command = new UpdateEmployeeCommand(employeeRepository, mapper);
                command.Model = model;
                command.Id = id;
                return await command.Handle() == true ? Ok() : BadRequest("Error updating data");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                DeleteEmployeeCommand command = new DeleteEmployeeCommand(employeeRepository);
                command.Id = id;
                return await command.Handle() == true ? Ok() : BadRequest("Error deleting data");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}
