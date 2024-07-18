using TestTaskSmart.Server.DataAccess.Models;

namespace TestTaskSmart.Server.DTO.ModelViewsObjects.EmployeeDTOs
{
    public class CreateEmployeeDTO
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public int PositionId { get; set; }

        public int SubdivisionId { get; set; }

        public int PeoplePartnerId { get; set; }
    }
}
