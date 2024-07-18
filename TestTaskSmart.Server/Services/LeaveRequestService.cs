using AutoMapper;
using TestTaskSmart.Server.DataAccess.Interfaces;
using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.Services.ServicesInterfaces;
using TestTaskSmart.Server.DataAccess.Models;
using TestTaskSmart.Server.DTO.ModelViewsObjects.LeaveRequestDTOs;

namespace TestTaskSmart.Server.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequests _leaveRequestRepo;
        private readonly IApprovalRequests _approvalRequests;
        private readonly IEmployees _employees;
        private readonly IMapper _mapper;
        private int _pageSize = 25;

        public LeaveRequestService(ILeaveRequests leaveRequestRepo, IMapper mapper, IApprovalRequests approvalRequests, IEmployees employees)
        {
            _leaveRequestRepo = leaveRequestRepo;
            _mapper = mapper;
            _approvalRequests = approvalRequests;
            _employees = employees;
        }

        public Pagination<LeaveRequestDTO> GetLeaveRequests(string? sortBy, string? sortType, string? searchString, int? pageNumber, int? id)
        {
            var leaveRequestsList = _mapper.Map<IEnumerable<LeaveRequestDTO>>(_leaveRequestRepo.LeaveRequestList());

            if (!string.IsNullOrEmpty(searchString))
            {
                leaveRequestsList = leaveRequestsList.Where(r => r.FormattedId.ToString().Contains(searchString));
            }

            if (id != null) 
            {
                leaveRequestsList = leaveRequestsList.Where(_r => _r.Employee.Id == id);
            }

            sortBy = string.IsNullOrEmpty(sortBy) ? "Id" : sortBy;

            leaveRequestsList = SortingHelper.SortByProperty(leaveRequestsList, sortBy, sortType);

            var pagination = Pagination<LeaveRequestDTO>.Create(leaveRequestsList, pageNumber ?? 1, _pageSize, searchString, sortBy, sortType);
            return pagination;
        }

        public LeaveRequestDTO GetLeaveRequestById(int id)
        {
            var leaveRequest = _leaveRequestRepo.GetById(id);
            return _mapper.Map<LeaveRequestDTO>(leaveRequest);
        }

        public void AddLeaveRequest(CreateLeaveRequestDTO leaveRequestDto)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestDto);
            leaveRequest.Status = LeaveStatus.New;

            _leaveRequestRepo.Add(leaveRequest);
        }

        public void UpdateLeaveRequest(EditLeaveRequestDTO leaveRequestDto)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestDto);
            var oldLeaveRequest = _leaveRequestRepo.GetById(leaveRequest.Id);
            leaveRequest.EmployeeId = oldLeaveRequest.EmployeeId;
            _leaveRequestRepo.Update(leaveRequest);
        }

        public void DeleteLeaveRequest(int id)
        {
            _leaveRequestRepo.Delete(id);
        }

        public void SubmitLeaveRequest(int id)
        {
            var leaveRequest = _leaveRequestRepo.GetById(id);
            leaveRequest.Status = LeaveStatus.Submitted;
            _leaveRequestRepo.Update(leaveRequest);
            ApprovalRequest approvalRequest = new ApprovalRequest();
            Employee employee = _employees.GetById(leaveRequest.EmployeeId);
            approvalRequest.Status = ApprovalStatus.New;
            approvalRequest.Comment = leaveRequest.Comment;
            approvalRequest.LeaveRequestId = leaveRequest.Id;
            approvalRequest.EmployeeId = employee.PeoplePartnerId ?? 0;
            _approvalRequests.Add(approvalRequest);
        }

        public void CancelLeaveRequest(int id)
        {
            var leaveRequest = _leaveRequestRepo.GetById(id);
            leaveRequest.Status = LeaveStatus.Canceled;
            _leaveRequestRepo.Update(leaveRequest);
        }
    }
}
