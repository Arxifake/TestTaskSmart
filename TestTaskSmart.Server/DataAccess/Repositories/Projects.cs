using Microsoft.EntityFrameworkCore;
using TestTaskSmart.Server.DataAccess.DBContext;
using TestTaskSmart.Server.DataAccess.Interfaces;
using TestTaskSmart.Server.DataAccess.Models;

namespace TestTaskSmart.Server.DataAccess.Repositories
{
    public class Projects : IProjects
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public Projects(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public List<Project> ProjectList(int? id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();

                var query = db.Projects
                    .Include(p => p.ProjectManager)
                    .Include(p => p.Employees)
                    .AsQueryable();

                if (id.HasValue)
                {
                    query = query.Where(p => p.Employees.Any(e => e.Id == id.Value));
                }

                return query.ToList();
            }
        }

        public Project GetById(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                return db.Projects
                    .Include(p => p.ProjectManager)
                    .First(p => p.Id == id);
            }
        }

        public void Add(Project project)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                db.Projects.Add(project);
                db.SaveChanges();
            }
        }

        public void Update(Project project)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                db.Projects.Update(project);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                var project = db.Projects.Find(id);
                if (project != null)
                {
                    db.Projects.Remove(project);
                    db.SaveChanges();
                }
            }
        }

        public void ChangeStatus(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                var project = db.Projects.Find(id);
                if (project != null)
                {
                    project.Status = !project.Status;
                    db.SaveChanges();
                }
            }
        }
    }
}