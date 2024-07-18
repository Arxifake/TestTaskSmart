using TestTaskSmart.Server.DataAccess.Models;

namespace TestTaskSmart.Server.DataAccess.Interfaces
{
    public interface IProjects
    {
        List<Project> ProjectList(int? id);
        Project GetById(int id);
        void Add(Project project);
        void Update(Project project);
        void Delete(int id);
        public void ChangeStatus(int id);
    }
}
