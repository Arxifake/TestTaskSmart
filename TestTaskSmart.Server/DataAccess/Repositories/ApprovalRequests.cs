using Microsoft.EntityFrameworkCore;
using TestTaskSmart.Server.DataAccess.DBContext;
using TestTaskSmart.Server.DataAccess.Interfaces;
using TestTaskSmart.Server.DataAccess.Models;

namespace TestTaskSmart.Server.DataAccess.Repositories
{
    public class ApprovalRequests : IApprovalRequests
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public ApprovalRequests(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public List<ApprovalRequest> ApprovalRequestList()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                return db.ApprovalRequests
                    .Include(ar => ar.Employee)
                    .Include(ar => ar.LeaveRequest)
                    .ThenInclude(lr => lr.Employee)
                    .ToList();
            }
        }

        public ApprovalRequest GetById(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                return db.ApprovalRequests
                    .Include(ar => ar.Employee)
                    .Include(ar => ar.LeaveRequest)
                    .ThenInclude(lr => lr.Employee)
                    .First(ar => ar.Id == id);
            }
        }

        public void Add(ApprovalRequest approvalRequest)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                db.ApprovalRequests.Add(approvalRequest);
                db.SaveChanges();
            }
        }

        public void Update(ApprovalRequest approvalRequest)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                db.ApprovalRequests.Update(approvalRequest);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                var approvalRequest = db.ApprovalRequests.Find(id);
                if (approvalRequest != null)
                {
                    db.ApprovalRequests.Remove(approvalRequest);
                    db.SaveChanges();
                }
            }
        }

        public void SubmitRequest(int id)
        {

        }
    }
}