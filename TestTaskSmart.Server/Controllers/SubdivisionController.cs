using Microsoft.AspNetCore.Mvc;
using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.DTO.ModelViewsObjects.EmployeeDTOs;
using TestTaskSmart.Server.Services;
using TestTaskSmart.Server.Services.ServicesInterfaces;

namespace TestTaskSmart.Server.Controllers
{
    [ApiController]
    public class SubdivisionController : Controller
    {
        private readonly ISubdivisionService _subdivisionService;
        public SubdivisionController(ISubdivisionService subdivisionService)
        {
            _subdivisionService = subdivisionService;
        }

        [HttpGet("api/subdivisions")]
        public List<SubdivisionDTO> Partners()
        {
            return _subdivisionService.GetSubdivisions();
        }
    }
}
