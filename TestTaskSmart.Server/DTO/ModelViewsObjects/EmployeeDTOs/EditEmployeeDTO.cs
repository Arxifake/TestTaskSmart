namespace TestTaskSmart.Server.DTO.ModelViewsObjects.EmployeeDTOs
{
    public class EditEmployeeDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int PositionId { get; set; }

        public int SubdivisionId { get; set; }

        public int PeoplePartnerId { get; set; }

        public bool Status { get; set; }

        public int Balance { get; set; }
    }
}
