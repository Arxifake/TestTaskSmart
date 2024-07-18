using AutoMapper;
using TestTaskSmart.Server.DataAccess.Interfaces;
using TestTaskSmart.Server.DataAccess.Models;
using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.DTO.ModelViewsObjects.EmployeeDTOs;
using TestTaskSmart.Server.Services.ServicesInterfaces;

namespace TestTaskSmart.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployees _employeeRepo;
        private readonly IMapper _mapper;
        private int _pageSize = 25;

        public EmployeeService(IEmployees employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public Pagination<PublicEmployeeDTO> EmployeeList(string? sortBy, string? sortType, string? searchString, int? pageNumber)
        {
            var employeesList = _mapper.Map<IEnumerable<PublicEmployeeDTO>>(_employeeRepo.EmployeeList());

            if (!string.IsNullOrEmpty(searchString))
            {
                employeesList = employeesList.Where(e => e.FullName.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            sortBy = string.IsNullOrEmpty(sortBy) ? "FullName" : sortBy;

            employeesList = SortingHelper.SortByProperty(employeesList, sortBy, sortType);

            var pagination = Pagination<PublicEmployeeDTO>.Create(employeesList, pageNumber ?? 1, _pageSize, searchString, sortBy, sortType);
            return pagination;
        }

        public PublicEmployeeDTO GetEmployeeById(int id)
        {
            var employee = _employeeRepo.GetById(id);
            return _mapper.Map<PublicEmployeeDTO>(employee);
        }

        public void AddEmployee(CreateEmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            employee.Status = true;
            employee.Balance = 5;
            _employeeRepo.Add(employee);
        }

        public void UpdateEmployee(EditEmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            var oldEmp = _employeeRepo.GetById(employee.Id);
            employee.Login = oldEmp.Login;
            employee.Password = oldEmp.Password;
            _employeeRepo.Update(employee);
        }

        public void ChangeStatus(int employeeId)
        {
            _employeeRepo.ChangeStatus(employeeId);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepo.Delete(id);
        }

        public List<PartnerDTO> Partners() 
        {
            return _mapper.Map<List<PartnerDTO>>(_employeeRepo.GetPartners());
        }

        public EditEmployeeDTO GetEmployeeToEdit(int id)
        {
            var employee = _employeeRepo.GetById(id);
            return _mapper.Map<EditEmployeeDTO>(employee);
        }

        public AuthResponse? Login(LoginDTO loginDto)
        {
            var employee = _employeeRepo.GetByLogin(loginDto.Login);
            if (employee != null && employee.Password == loginDto.Password) {
                return new AuthResponse()
                {
                    Id = employee.Id,
                    Position = employee.Position.Name
                };
            }
            return null;
        }

        public void AssignEmployeeToProject(EmployeeProjectDTO employeeProject)
        {
            _employeeRepo.AssignEmployeeToProject(_mapper.Map<EmployeesProjects>(employeeProject));
        }

    }
}
