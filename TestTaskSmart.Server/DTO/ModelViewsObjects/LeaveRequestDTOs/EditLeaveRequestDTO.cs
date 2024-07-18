using TestTaskSmart.Server.DTO.ModelViewsObjects.EmployeeDTOs;

namespace TestTaskSmart.Server.DTO.ModelViewsObjects.LeaveRequestDTOs
{
    public class EditLeaveRequestDTO
    {
        public int Id { get; set; }

        public string FormattedId => $"LR{Id:D3}";

        public string Comment { get; set; }

        public string Status { get; set; }

        public string AbsenceReason { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
