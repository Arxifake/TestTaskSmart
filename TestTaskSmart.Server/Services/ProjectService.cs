using AutoMapper;
using TestTaskSmart.Server.DataAccess.Interfaces;
using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.Services.ServicesInterfaces;
using TestTaskSmart.Server.DataAccess.Models;

namespace TestTaskSmart.Server.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjects _projectRepo;
        private readonly IMapper _mapper;
        private int _pageSize = 25;

        public ProjectService(IProjects projectRepo, IMapper mapper)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
        }

        public Pagination<ProjectDTO> GetProjects(string? sortBy, string? sortType, string? searchString, int? pageNumber, int? id)
        {
            var projectsList = _mapper.Map<IEnumerable<ProjectDTO>>(_projectRepo.ProjectList(id));

            if (!string.IsNullOrEmpty(searchString))
            {
                projectsList = projectsList.Where(p => p.FormattedId.ToString().Contains(searchString));
            }

            sortBy = string.IsNullOrEmpty(sortBy) ? "Id" : sortBy;

            projectsList = SortingHelper.SortByProperty(projectsList, sortBy, sortType);

            var pagination = Pagination<ProjectDTO>.Create(projectsList, pageNumber ?? 1, _pageSize, searchString, sortBy, sortType);
            return pagination;
        }

        public ProjectDTO GetProjectById(int id)
        {
            var project = _projectRepo.GetById(id);
            return _mapper.Map<ProjectDTO>(project);
        }

        public void AddProject(ProjectDTO projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            _projectRepo.Add(project);
        }

        public void UpdateProject(ProjectDTO projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            _projectRepo.Update(project);
        }

        public void DeleteProject(int id)
        {
            _projectRepo.Delete(id);
        }

        public void ChangeStatus(int id)
        {
            _projectRepo.ChangeStatus(id);
        }
    }
}
