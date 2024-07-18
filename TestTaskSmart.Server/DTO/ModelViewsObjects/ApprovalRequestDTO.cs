using TestTaskSmart.Server.DTO.ModelViewsObjects.EmployeeDTOs;
using TestTaskSmart.Server.DTO.ModelViewsObjects.LeaveRequestDTOs;

namespace TestTaskSmart.Server.DTO.ModelViewsObjects
{
    public class ApprovalRequestDTO
    {
        public int Id { get; set; }
        public string FormattedId => $"AR{Id:D3}";

        public EmployeeDTO Employee { get; set; }

        public string Comment { get; set; }

        public string Status { get; set; }

        public int LeaveRequestId { get; set; }

        public LeaveRequestDTO LeaveRequest { get; set; }

        public bool IsSubmited { get; set; }
    }
}