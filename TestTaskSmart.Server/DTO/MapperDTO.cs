using AutoMapper;
using TestTaskSmart.Server.DataAccess.Models;
using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.DTO.ModelViewsObjects.EmployeeDTOs;
using TestTaskSmart.Server.DTO.ModelViewsObjects.LeaveRequestDTOs;

namespace TestTaskSmart.Server.DTO
{
    public class MapperDTO:Profile
    {
        public MapperDTO() 
        {
            CreateMap<PartnerDTO,Employee>().ReverseMap();
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
            CreateMap<PublicEmployeeDTO, Employee>().ReverseMap();
            CreateMap<CreateEmployeeDTO, Employee>().ReverseMap();
            CreateMap<ApprovalRequestDTO, ApprovalRequest>().ReverseMap();
            CreateMap<LeaveRequestDTO, LeaveRequest>().ReverseMap();
            CreateMap<ProjectDTO, Project>().ReverseMap();
            CreateMap<SubdivisionDTO, Subdivision>().ReverseMap();
            CreateMap<PositionDTO, Position>().ReverseMap();
            CreateMap<EditEmployeeDTO, Employee>().ReverseMap();
            CreateMap<CreateLeaveRequestDTO,LeaveRequest>().ReverseMap();
            CreateMap<EditLeaveRequestDTO, LeaveRequest>().ReverseMap();
            CreateMap<EmployeeProjectDTO, EmployeesProjects>().ReverseMap();
        }
    }
}
