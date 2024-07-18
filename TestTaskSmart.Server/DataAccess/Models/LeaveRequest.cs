namespace TestTaskSmart.Server.DataAccess.Models
{
    public class LeaveRequest : Request
    {
        public AbsenceReason AbsenceReason { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ApprovalRequest ApprovalRequest { get; set; }

        public LeaveStatus Status { get; set; }
    }

    public enum AbsenceReason
    {
        SickLeave = 0,
        Vacation = 1,
        PersonalLeave = 2,
        UnpaidLeave = 3,
        Other = 4
    }

    public enum LeaveStatus
    {
        New = 0,
        Canceled = 1,
        Submitted = 2,
        Approved = 3,
        Rejected = 4
    }
}
