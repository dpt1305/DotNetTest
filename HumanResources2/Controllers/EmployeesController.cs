using HumanResources2.DTO;
using HumanResources2.Interfaces;
using HumanResources2.Model;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources2.Controllers
{
    [ApiController]
    [Route("/api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeesController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDto employeeDto)
        {
            string name = employeeDto.Name ?? "N/A";
            int age = employeeDto.Age ?? 0;
            string? departureId = employeeDto.DepartureId ?? null;
            string guid = Guid.NewGuid().ToString();

            Employee newEmployee = (departureId == null)
                ? new Employee(guid, name, age)
                : new Employee(guid, name, age, departureId);
            try
            {
                IEnumerable<Employee> employees = await _employeeRepo.Create(newEmployee);
                return Ok(newEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                IEnumerable<Employee> employees = await _employeeRepo.FindAll();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            try
            {
                IEnumerable<Employee> employees = await _employeeRepo.FindOneById(id);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {

                IEnumerable<Employee> employees = await _employeeRepo.Update(employee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                IEnumerable<Employee> employees = await _employeeRepo.Delete(id);
                return Ok("Delete successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}

