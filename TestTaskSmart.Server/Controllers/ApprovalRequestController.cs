using Microsoft.AspNetCore.Mvc;
using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.Services.ServicesInterfaces;

namespace TestTaskSmart.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApprovalRequestController : ControllerBase
    {
        private readonly IApprovalRequestService _approvalRequestService;

        public ApprovalRequestController(IApprovalRequestService approvalRequestService)
        {
            _approvalRequestService = approvalRequestService;
        }

        [HttpGet]
        public ActionResult<Pagination<ApprovalRequestDTO>> Get(string? sortBy, string? sortType, string? searchString, int? pageNumber)
        {
            var approvalRequests = _approvalRequestService.GetApprovalRequests(sortBy, sortType, searchString, pageNumber);
            return Ok(approvalRequests);
        }

        [HttpGet("{id}")]
        public ActionResult<ApprovalRequestDTO> Get(int id)
        {
            var approvalRequest = _approvalRequestService.GetApprovalRequestById(id);
            return Ok(approvalRequest);
        }

        [HttpPost]
        public ActionResult Add([FromBody] ApprovalRequestDTO approvalRequestDto)
        {
            _approvalRequestService.AddApprovalRequest(approvalRequestDto);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] ApprovalRequestDTO approvalRequestDto)
        {
            _approvalRequestService.UpdateApprovalRequest(approvalRequestDto);
            return Ok();
        }

        [HttpPost("approve")]
        public ActionResult Approve([FromBody] int id)
        {
            _approvalRequestService.ApproveApprovalRequest(id);
            return Ok();
        }

        [HttpPost("reject")]
        public ActionResult Reject([FromBody] int id)
        {
            _approvalRequestService.RejectApprovalRequest(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _approvalRequestService.DeleteApprovalRequest(id);
            return Ok();
        }
    }
}
