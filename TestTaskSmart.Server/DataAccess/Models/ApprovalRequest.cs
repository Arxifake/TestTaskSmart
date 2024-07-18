namespace TestTaskSmart.Server.DataAccess.Models
{
    public class ApprovalRequest : Request
    {
        public LeaveRequest LeaveRequest { get; set; }
        public int LeaveRequestId { get; set; }
        public ApprovalStatus Status { get; set; }
    }

    public enum ApprovalStatus
    {
        New = 0,
        Approved = 1,
        Rejected = 2
    }
}
