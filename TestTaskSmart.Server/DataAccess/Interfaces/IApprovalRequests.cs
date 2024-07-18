using TestTaskSmart.Server.DataAccess.Models;

namespace TestTaskSmart.Server.DataAccess.Interfaces
{
    public interface IApprovalRequests
    {
        List<ApprovalRequest> ApprovalRequestList();
        ApprovalRequest GetById(int id);
        void Add(ApprovalRequest approvalRequest);
        void Update(ApprovalRequest approvalRequest);
        void Delete(int id);
    }
}
