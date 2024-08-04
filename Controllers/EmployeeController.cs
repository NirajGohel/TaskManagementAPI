using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Entities;
using TaskManagementAPI.Interface;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {        
        private readonly IEmployee _employeeRepository;

        public EmployeeController(IEmployee employeeRepository)
        {            
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {            
            var employees = await _employeeRepository.GetAllEmployees();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {            
            var employee = await _employeeRepository.GetEmployeeById(id);

            if(employee.Id == 0)
            {
                return NotFound("Employee not found.");
            }

            return Ok(employee);
        }

        [HttpPost("Signup")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {            
            var newEmployee = await _employeeRepository.AddEmployee(employee);            

            return CreatedAtAction("AddEmployee", newEmployee);
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee updatedEmployee)
        {
            var newEmployee = await _employeeRepository.UpdateEmployee(updatedEmployee);

            return Ok(newEmployee);
        }

        [HttpDelete]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.DeleteEmployee(id);

            return Ok(employee);
        }
    }
}
