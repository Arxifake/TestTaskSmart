namespace TestTaskSmart.Server.DTO.ModelViewsObjects.LeaveRequestDTOs
{
    public class CreateLeaveRequestDTO
    {
        public string Comment { get; set; }

        public string AbsenceReason { get; set; }

        public int EmployeeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
