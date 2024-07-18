using TestTaskSmart.Server.DTO.ModelViewsObjects.EmployeeDTOs;

namespace TestTaskSmart.Server.DTO.ModelViewsObjects
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string FormattedId => $"PRJ{Id:D3}";

        public string Type { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public PartnerDTO ProjectManager { get; set; }

        public string Comment { get; set; }

        public bool Status { get; set; }
    }
}