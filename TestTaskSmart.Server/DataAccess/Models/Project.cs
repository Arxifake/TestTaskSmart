namespace TestTaskSmart.Server.DataAccess.Models
{
    public class Project
    {
        public int Id { get; set; }

        public ProjectTypes Type { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ProjectManagerId { get; set; }
        public Employee ProjectManager { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public string Comment { get; set; }

        public bool Status { get; set; }
    }

    public enum ProjectTypes
    {
        SoftwareDevelopment = 0, 
        ResearchAndDevelopment = 1,
        Maintenance = 2,
    }
}
