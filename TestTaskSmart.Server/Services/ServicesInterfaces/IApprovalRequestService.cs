using TestTaskSmart.Server.DTO.ModelViewsObjects;

namespace TestTaskSmart.Server.Services.ServicesInterfaces
{
    public interface IApprovalRequestService
    {
        Pagination<ApprovalRequestDTO> GetApprovalRequests(string? sortBy, string? sortType, string? searchString, int? pageNumber);
        ApprovalRequestDTO GetApprovalRequestById(int id);
        void AddApprovalRequest(ApprovalRequestDTO approvalRequestDto);
        void UpdateApprovalRequest(ApprovalRequestDTO approvalRequestDto);
        void ApproveApprovalRequest(int id);
        void RejectApprovalRequest(int id);
        void DeleteApprovalRequest(int id);
    }
}