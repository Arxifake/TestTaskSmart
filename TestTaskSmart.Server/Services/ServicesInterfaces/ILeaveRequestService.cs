using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.DTO.ModelViewsObjects.LeaveRequestDTOs;

namespace TestTaskSmart.Server.Services.ServicesInterfaces
{
    public interface ILeaveRequestService
    {
        Pagination<LeaveRequestDTO> GetLeaveRequests(string? sortBy, string? sortType, string? searchString, int? pageNumber, int? id);
        LeaveRequestDTO GetLeaveRequestById(int id);
        void AddLeaveRequest(CreateLeaveRequestDTO leaveRequestDto);
        void UpdateLeaveRequest(EditLeaveRequestDTO leaveRequestDto);
        void DeleteLeaveRequest(int id);
        void CancelLeaveRequest(int id);
        void SubmitLeaveRequest(int id);
    }
}