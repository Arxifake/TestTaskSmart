using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskSmart.Server.DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Login {  get; set; }

        public string Password { get; set; }
        
        public string FullName { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int SubdivisionId { get; set; }
        public Subdivision Subdivision { get; set; }

        public bool Status { get; set; }

        public int? PeoplePartnerId { get; set; }

        public Employee PeoplePartner { get; set; }

        public ICollection<Project> Projects { get; set; }

        public int Balance { get; set; }
    }
}
