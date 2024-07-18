using TestTaskSmart.Server.DataAccess.Models;

namespace TestTaskSmart.Server.DTO.ModelViewsObjects.EmployeeDTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public SubdivisionDTO Subdivision { get; set; }

        public PositionDTO Position { get; set; }

        public bool Status { get; set; }

        public PartnerDTO PeoplePartner { get; set; }

        public int Balance { get; set; }
    }
}
