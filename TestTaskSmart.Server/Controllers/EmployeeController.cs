using Microsoft.AspNetCore.Mvc;
using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.DTO.ModelViewsObjects.EmployeeDTOs;
using TestTaskSmart.Server.Services.ServicesInterfaces;

namespace TestTaskSmart.Server.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("api/employees")]
        public Pagination<PublicEmployeeDTO> Get(string? sortBy, string? sortType, string? searchString, int? pageNumber)
        {
            var show = _employeeService.EmployeeList(sortBy, sortType, searchString, pageNumber);
            return show;
        }

        [HttpGet("api/employees/{id}")]
        public PublicEmployeeDTO GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            return employee;
        }

        [HttpGet("api/employees/edit{id}")]
        public EditEmployeeDTO GetEmployeeToEdit(int id)
        {
            var employee = _employeeService.GetEmployeeToEdit(id);
            return employee;
        }

        [HttpPost("api/employees")]
        public ActionResult AddEmployee([FromBody] CreateEmployeeDTO employeeDto)
        {
            _employeeService.AddEmployee(employeeDto);
            return Ok();
        }

        [HttpPut("api/employees/{id}")]
        public ActionResult UpdateEmployee(int id, [FromBody] EditEmployeeDTO employeeDto)
        {
            if (id != employeeDto.Id)
            {
                return BadRequest();
            }
            _employeeService.UpdateEmployee(employeeDto);
            return NoContent();
        }

        [HttpDelete("api/employees/{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployee(id);
            return NoContent();
        }

        [HttpPost("api/employees/status")]
        public ActionResult ChangeStatus([FromBody] int id)
        {
            _employeeService.ChangeStatus(id);
            return Ok();
        }

        [HttpGet("api/employees/partners")]
        public List<PartnerDTO> Partners()
        {
            return _employeeService.Partners();
        }

        [HttpPost("api/login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            var authResponse = _employeeService.Login(loginDTO);
            if (authResponse == null)
            {
                return Unauthorized(new { message = "Invalid login credentials" });
            }
            return Ok(authResponse);
        }

        [HttpPost("api/employees/assign")]
        public ActionResult AssignToProject([FromBody] EmployeeProjectDTO empProj)
        {
            _employeeService.AssignEmployeeToProject(empProj);
            return Ok();
        }
    }
}
