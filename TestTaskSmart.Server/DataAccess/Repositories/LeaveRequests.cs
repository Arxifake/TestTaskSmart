using Microsoft.EntityFrameworkCore;
using TestTaskSmart.Server.DataAccess.DBContext;
using TestTaskSmart.Server.DataAccess.Interfaces;
using TestTaskSmart.Server.DataAccess.Models;

namespace TestTaskSmart.Server.DataAccess.Repositories
{
    public class LeaveRequests : ILeaveRequests
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public LeaveRequests(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public List<LeaveRequest> LeaveRequestList()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                return db.LeaveRequests
                    .Include(lr => lr.Employee)
                    .ToList();
            }
        }

        public LeaveRequest GetById(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                return db.LeaveRequests
                    .Include(lr => lr.Employee)
                    .First(lr => lr.Id == id);
            }
        }

        public void Add(LeaveRequest leaveRequest)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                db.LeaveRequests.Add(leaveRequest);
                db.SaveChanges();
            }
        }

        public void Update(LeaveRequest leaveRequest)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                db.LeaveRequests.Update(leaveRequest);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                var leaveRequest = db.LeaveRequests.Find(id);
                if (leaveRequest != null)
                {
                    db.LeaveRequests.Remove(leaveRequest);
                    db.SaveChanges();
                }
            }
        }
    }
}