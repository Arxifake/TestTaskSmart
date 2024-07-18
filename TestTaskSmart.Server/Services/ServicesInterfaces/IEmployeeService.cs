using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.DTO.ModelViewsObjects.EmployeeDTOs;

namespace TestTaskSmart.Server.Services.ServicesInterfaces
{
    public interface IEmployeeService
    {
        public Pagination<PublicEmployeeDTO> EmployeeList(string? sortBy, string? sortType, string? searchString, int? pageNumber);
        PublicEmployeeDTO GetEmployeeById(int id);
        void AddEmployee(CreateEmployeeDTO employeeDto);
        void UpdateEmployee(EditEmployeeDTO employeeDto);
        void ChangeStatus(int employeeId);
        void DeleteEmployee(int id);
        List<PartnerDTO> Partners();
        EditEmployeeDTO GetEmployeeToEdit(int id);
        AuthResponse? Login(LoginDTO loginDto);
        void AssignEmployeeToProject(EmployeeProjectDTO employeeProject);
    }
}
