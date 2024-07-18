namespace TestTaskSmart.Server.DataAccess.Models
{
    public abstract class Request
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        public string Comment { get; set; }

    }
}
