using TestTaskSmart.Server.DTO.ModelViewsObjects;

namespace TestTaskSmart.Server.Services.ServicesInterfaces
{
    public interface IProjectService
    {
        Pagination<ProjectDTO> GetProjects(string? sortBy, string? sortType, string? searchString, int? pageNumber, int? id);
        ProjectDTO GetProjectById(int id);
        void AddProject(ProjectDTO projectDto);
        void UpdateProject(ProjectDTO projectDto);
        void DeleteProject(int id);
        void ChangeStatus(int id);
    }
}