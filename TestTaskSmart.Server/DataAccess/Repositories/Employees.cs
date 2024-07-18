using Microsoft.EntityFrameworkCore;
using TestTaskSmart.Server.DataAccess.DBContext;
using TestTaskSmart.Server.DataAccess.Interfaces;
using TestTaskSmart.Server.DataAccess.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TestTaskSmart.Server.DataAccess.Repositories
{
    public class Employees: IEmployees
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public Employees(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public List<Employee> EmployeeList() 
        {
            using (var scope = _scopeFactory.CreateScope()) 
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                return db.Employees
                    .Include(e => e.Position)
                    .Include(e => e.Subdivision)
                    .ToList();
            }  
        }

        public Employee GetById(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                return db.Employees
                    .Include(e => e.Position)
                    .Include(e => e.Subdivision)
                    .First(e => e.Id == id);
            }
        }

        public void Add(Employee employee)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public void Update(Employee employee)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                db.Employees.Update(employee);
                db.SaveChanges();
            }
        }

        public void ChangeStatus(int employeeId)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                var employee = db.Employees.Find(employeeId);
                if (employee != null)
                {
                    employee.Status = !employee.Status;
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                var employee = db.Employees.Find(id);
                if (employee != null)
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                }
            }
        }

        public List<Employee> GetPartners() 
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                return db.Employees
                    .Where(e=>e.Position.Name=="HR")
                    .ToList();
            }
        }

        public Employee GetByLogin(string login)
        {
            using ( var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                return db.Employees
                    .Include(e=>e.Position)
                    .First(e => e.Login == login);
            }
        }

        public void AssignEmployeeToProject(EmployeesProjects empProj)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                db.EmployeesProjects.Add(empProj);
                db.SaveChanges();
            }
        }
    }
}
