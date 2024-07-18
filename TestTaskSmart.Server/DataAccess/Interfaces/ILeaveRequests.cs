using TestTaskSmart.Server.DataAccess.Models;

namespace TestTaskSmart.Server.DataAccess.Interfaces
{
    public interface ILeaveRequests
    {
        List<LeaveRequest> LeaveRequestList();
        LeaveRequest GetById(int id);
        void Add(LeaveRequest leaveRequest);
        void Update(LeaveRequest leaveRequest);
        void Delete(int id);
    }
}
