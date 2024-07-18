using Microsoft.AspNetCore.Mvc;
using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.DTO.ModelViewsObjects.EmployeeDTOs;
using TestTaskSmart.Server.Services;
using TestTaskSmart.Server.Services.ServicesInterfaces;

namespace TestTaskSmart.Server.Controllers
{
    [ApiController]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet("api/positions")]
        public List<PositionDTO> Positions()
        {
            return _positionService.GetPositions();
        }
    }
}
