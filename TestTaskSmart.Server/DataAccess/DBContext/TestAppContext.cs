using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TestTaskSmart.Server.DataAccess.Models;
using Bogus;
using Bogus.DataSets;
using System;

namespace TestTaskSmart.Server.DataAccess.DBContext
{
    public class TestAppContext: DbContext
    {
        public TestAppContext(DbContextOptions<TestAppContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<EmployeesProjects> EmployeesProjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.PeoplePartner)
                .WithMany()
                .HasForeignKey(e => e.PeoplePartnerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApprovalRequest>()
                .HasOne(ar => ar.LeaveRequest)
                .WithOne(lr => lr.ApprovalRequest)
                .HasForeignKey<ApprovalRequest>(ar => ar.LeaveRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasMany(p => p.Projects)
                .WithMany(p => p.Employees)
                .UsingEntity<EmployeesProjects>();

            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectManager)
                .WithMany()
                .HasForeignKey(p => p.ProjectManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            List<Position> positions = new List<Position>();
            positions.AddRange(new List<Position>
            {
                new Position
                {
                    Id=1,
                    Name="Admin"
                },
                new Position
                {
                    Id=2,
                    Name="HR"
                },
                new Position
                {
                    Id=3,
                    Name="PM"
                },
                new Position
                {
                    Id=4,
                    Name="Employee"
                }
            });
            modelBuilder.Entity<Position>().HasData(positions);

            List<Subdivision> subdivisions = new List<Subdivision>();
            subdivisions.AddRange(new List<Subdivision>
            {
                new Subdivision
                {
                    Id=1,
                    Name="Admin"
                },
                new Subdivision
                {
                    Id=2,
                    Name="Subdivision1"
                },
                new Subdivision
                {
                    Id=3,
                    Name="Subdivision2"
                }
            });
            modelBuilder.Entity<Subdivision>().HasData(subdivisions);

            List<Employee> employees = new List<Employee>();
            employees.AddRange(new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Login="admin",
                    Password="admin",
                    FullName="Admin Admin",
                    PositionId=1,
                    Status=true,
                    SubdivisionId=1,
                    Balance=0
                },
                new Employee
                {
                    Id=2,
                    Login = "hr1",
                    Password = "hr1",
                    FullName = "Alice HR",
                    PositionId = 2,
                    Status = true,
                    SubdivisionId = 2,
                    Balance = 0
                },
                new Employee
                {
                    Id=3,
                    Login = "hr2",
                    Password = "hr2",
                    FullName = "Bob HR",
                    PositionId = 2,
                    Status = true,
                    SubdivisionId = 3,
                    Balance = 0
                },
                new Employee
                {
                    Id=4,
                    Login = "pm1",
                    Password = "pm1",
                    FullName = "Charlie PM",
                    PositionId = 3,
                    Status = true,
                    SubdivisionId = 2,
                    Balance = 0
                },
                new Employee
                {
                    Id=5,
                    Login = "pm2",
                    Password = "pm2",
                    FullName = "David PM",
                    PositionId = 3,
                    Status = true,
                    SubdivisionId = 3,
                    Balance = 0
                },
                new Employee
                {
                    Id=6,
                    Login = "emp1",
                    Password = "emp1",
                    FullName = "Emma Emp",
                    PositionId = 4,
                    Status = true,
                    SubdivisionId = 2,
                    Balance = 5
                },
                new Employee
                {
                    Id=7,
                    Login = "emp2",
                    Password = "emp2",
                    FullName = "Liam Emp",
                    PositionId = 4,
                    Status = true,
                    SubdivisionId = 3,
                    Balance = 5
                }
            });
            modelBuilder.Entity<Employee>().HasData(employees);

            List<Employee> randomEmployees = new List<Employee>();
            var faker = new Faker();

            for (int i = 0; i < 50; i++)
            {
                string randomName = faker.Name.FullName();
                string randomLogin = faker.Internet.UserName();
                string randomPassword = faker.Internet.Password();
                bool randomStatus = new Random().Next(0, 2) == 0;
                int subId = i < 25 ? 2 : 3;
                int randomBalance = new Random().Next(1, 31);
                int partnerId = i < 25 ? 2 : 3;
                var employee = new Employee { Id = i + 8, FullName = randomName, Login = randomLogin, Password = randomPassword, PositionId = 4, Status = randomStatus, SubdivisionId = subId, Balance = randomBalance, PeoplePartnerId = partnerId };
                randomEmployees.Add(employee);
            }

            modelBuilder.Entity<Employee>().HasData(randomEmployees);

            List<LeaveRequest> leaveRequests = new List<LeaveRequest>();
            leaveRequests.AddRange(new List<LeaveRequest>
            {
                new LeaveRequest
                {
                    Id = 1,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    AbsenceReason = AbsenceReason.SickLeave,
                    EmployeeId = 9,
                    Status = LeaveStatus.New,
                    Comment = ""
                },
                new LeaveRequest
                {
                    Id = 2,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    AbsenceReason = AbsenceReason.Vacation,
                    EmployeeId = 10,
                    Status = LeaveStatus.New,
                    Comment = ""
                },
                new LeaveRequest
                {
                    Id = 3,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    AbsenceReason = AbsenceReason.PersonalLeave,
                    EmployeeId = 14,
                    Status = LeaveStatus.New,
                    Comment = ""
                },
                new LeaveRequest
                {
                    Id = 4,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    AbsenceReason = AbsenceReason.UnpaidLeave,
                    EmployeeId = 32,
                    Status = LeaveStatus.New,
                    Comment = ""
                },
                new LeaveRequest
                {
                    Id = 5,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    AbsenceReason = AbsenceReason.Other,
                    EmployeeId = 31,
                    Status = LeaveStatus.Canceled,
                    Comment = ""
                },

                });
            modelBuilder.Entity<LeaveRequest>().HasData(leaveRequests);

            List<Project> projects = new List<Project>();
            projects.AddRange(new List<Project>()
            {
                new Project
                {
                    Id= 1,
                    Type = ProjectTypes.SoftwareDevelopment,
                    StartDate= DateTime.Now,
                    EndDate= DateTime.Now,
                    ProjectManagerId= 4,
                    Status = true,
                    Comment = ""
                },
                new Project
                {
                    Id= 2,
                    Type = ProjectTypes.Maintenance,
                    StartDate= DateTime.Now,
                    EndDate= DateTime.Now,
                    ProjectManagerId= 4,
                    Status = true,
                    Comment = ""
                },
                new Project
                {
                    Id= 3,
                    Type = ProjectTypes.ResearchAndDevelopment,
                    StartDate= DateTime.Now,
                    EndDate= DateTime.Now,
                    ProjectManagerId= 5,
                    Status = true,
                    Comment = ""
                },
            });
            modelBuilder.Entity<Project>().HasData(projects);

            List<EmployeesProjects> employeesProjects = new List<EmployeesProjects>();
            employeesProjects.AddRange(new List<EmployeesProjects>()
            {
                new EmployeesProjects
                {
                    EmployeeId = 14,
                    ProjectId= 1,
                },
                new EmployeesProjects
                {
                    EmployeeId = 25,
                    ProjectId= 1,
                },
                new EmployeesProjects
                {
                    EmployeeId = 13,
                    ProjectId= 2,
                },
                new EmployeesProjects
                {
                    EmployeeId = 11,
                    ProjectId= 2,
                },
                new EmployeesProjects
                {
                    EmployeeId = 31,
                    ProjectId= 3,
                },
                new EmployeesProjects
                {
                    EmployeeId = 33,
                    ProjectId= 3,
                },
            });
            modelBuilder.Entity<EmployeesProjects>().HasData(employeesProjects);
        }
    }
}
