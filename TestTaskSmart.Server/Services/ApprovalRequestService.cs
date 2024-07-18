using AutoMapper;
using TestTaskSmart.Server.DataAccess.Interfaces;
using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.Services.ServicesInterfaces;
using TestTaskSmart.Server.DataAccess.Models;

namespace TestTaskSmart.Server.Services
{
    public class ApprovalRequestService : IApprovalRequestService
    {
        private readonly IApprovalRequests _approvalRequestRepo;
        private readonly ILeaveRequests _leaveRequestRepo;
        private readonly IEmployees _employees;
        private readonly IMapper _mapper;
        private int _pageSize = 25;

        public ApprovalRequestService(IApprovalRequests approvalRequestRepo, IMapper mapper, IEmployees employees, ILeaveRequests leaveRequests)
        {
            _approvalRequestRepo = approvalRequestRepo;
            _mapper = mapper;
            _employees = employees;
            _leaveRequestRepo = leaveRequests;
        }

        public Pagination<ApprovalRequestDTO> GetApprovalRequests(string? sortBy, string? sortType, string? searchString, int? pageNumber)
        {
            var approvalRequestsList = _mapper.Map<IEnumerable<ApprovalRequestDTO>>(_approvalRequestRepo.ApprovalRequestList());

            if (!string.IsNullOrEmpty(searchString))
            {
                approvalRequestsList = approvalRequestsList.Where(r => r.FormattedId.ToString().Contains(searchString));
            }

            sortBy = string.IsNullOrEmpty(sortBy) ? "Id" : sortBy;

            approvalRequestsList = SortingHelper.SortByProperty(approvalRequestsList, sortBy, sortType);

            var pagination = Pagination<ApprovalRequestDTO>.Create(approvalRequestsList, pageNumber ?? 1, _pageSize, searchString, sortBy, sortType);
            return pagination;
        }

        public ApprovalRequestDTO GetApprovalRequestById(int id)
        {
            var approvalRequest = _mapper.Map<ApprovalRequestDTO>(_approvalRequestRepo.GetById(id));
            var totalDays = (approvalRequest.LeaveRequest.EndDate - approvalRequest.LeaveRequest.StartDate).TotalDays+1;
            approvalRequest.IsSubmited = totalDays<=approvalRequest.LeaveRequest.Employee.Balance;
            return approvalRequest;
        }

        public void AddApprovalRequest(ApprovalRequestDTO approvalRequestDto)
        {
            var approvalRequest = _mapper.Map<ApprovalRequest>(approvalRequestDto);
            _approvalRequestRepo.Add(approvalRequest);
        }

        public void UpdateApprovalRequest(ApprovalRequestDTO approvalRequestDto)
        {
            var approvalRequest = _mapper.Map<ApprovalRequest>(approvalRequestDto);
            _approvalRequestRepo.Update(approvalRequest);
        }

        public void ApproveApprovalRequest(int id)
        {
            var approvalRequest = _approvalRequestRepo.GetById(id);
            approvalRequest.Status = ApprovalStatus.Approved;
            _approvalRequestRepo.Update(approvalRequest);

            var emp = _employees.GetById(approvalRequest.LeaveRequest.EmployeeId);
            var totalDays = (approvalRequest.LeaveRequest.EndDate - approvalRequest.LeaveRequest.StartDate).TotalDays + 1;
            emp.Balance = (int)(emp.Balance - totalDays);
            _employees.Update(emp);

            var leaveRequest = _leaveRequestRepo.GetById(approvalRequest.LeaveRequestId);
            leaveRequest.Status = LeaveStatus.Approved;
            _leaveRequestRepo.Update(leaveRequest);
        }

        public void RejectApprovalRequest(int id)
        {
            var approvalRequest = _approvalRequestRepo.GetById(id);
            approvalRequest.Status = ApprovalStatus.Rejected;
            _approvalRequestRepo.Update(approvalRequest);

            var leaveRequest = _leaveRequestRepo.GetById(approvalRequest.LeaveRequestId);
            leaveRequest.Status = LeaveStatus.Rejected;
            _leaveRequestRepo.Update(leaveRequest);
        }

        public void DeleteApprovalRequest(int id)
        {
            _approvalRequestRepo.Delete(id);
        }
    }
}
