using TestTaskSmart.Server.DTO.ModelViewsObjects.EmployeeDTOs;

namespace TestTaskSmart.Server.DTO.ModelViewsObjects.LeaveRequestDTOs
{
    public class LeaveRequestDTO
    {
        public int Id { get; set; }

        public string FormattedId => $"LR{Id:D3}";

        public EmployeeDTO Employee { get; set; }

        public string Comment { get; set; }

        public string Status { get; set; }

        public string AbsenceReason { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}