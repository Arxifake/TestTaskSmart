using Microsoft.AspNetCore.Mvc;
using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.DTO.ModelViewsObjects.LeaveRequestDTOs;
using TestTaskSmart.Server.Services.ServicesInterfaces;

namespace TestTaskSmart.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequestController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        [HttpGet]
        public ActionResult<Pagination<LeaveRequestDTO>> Get(string? sortBy, string? sortType, string? searchString, int? pageNumber, int? id)
        {
            var leaveRequests = _leaveRequestService.GetLeaveRequests(sortBy, sortType, searchString, pageNumber, id);
            return Ok(leaveRequests);
        }

        [HttpGet("{id}")]
        public ActionResult<LeaveRequestDTO> Get(int id)
        {
            var leaveRequest = _leaveRequestService.GetLeaveRequestById(id);
            return Ok(leaveRequest);
        }

        [HttpPost]
        public ActionResult Add([FromBody] CreateLeaveRequestDTO leaveRequestDto)
        {
            _leaveRequestService.AddLeaveRequest(leaveRequestDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] EditLeaveRequestDTO leaveRequestDto)
        {
            _leaveRequestService.UpdateLeaveRequest(leaveRequestDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _leaveRequestService.DeleteLeaveRequest(id);
            return Ok();
        }

        [HttpPost("submit")]
        public ActionResult Submit([FromBody] int id)
        {
            _leaveRequestService.SubmitLeaveRequest(id);
            return Ok();
        }

        [HttpPost("cancel")]
        public ActionResult Cancel([FromBody] int id)
        {
            _leaveRequestService.CancelLeaveRequest(id);
            return Ok();
        }
    }
}
