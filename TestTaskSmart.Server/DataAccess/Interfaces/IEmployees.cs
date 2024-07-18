using TestTaskSmart.Server.DataAccess.Models;

namespace TestTaskSmart.Server.DataAccess.Interfaces
{
    public interface IEmployees
    {
        public List<Employee> EmployeeList();

        public Employee GetById(int id);

        public void Add(Employee employee);

        public void Update(Employee employee);

        public void ChangeStatus(int employeeId);

        public void Delete(int id);

        public List<Employee> GetPartners();

        public Employee GetByLogin(string login);
        public void AssignEmployeeToProject(EmployeesProjects empProj);
    }
}
