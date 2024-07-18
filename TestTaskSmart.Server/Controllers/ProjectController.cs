using Microsoft.AspNetCore.Mvc;
using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.Services;
using TestTaskSmart.Server.Services.ServicesInterfaces;

namespace TestTaskSmart.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public ActionResult<Pagination<ProjectDTO>> Get(string? sortBy, string? sortType, string? searchString, int? pageNumber, int? id)
        {
            var projects = _projectService.GetProjects(sortBy, sortType, searchString, pageNumber, id);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectDTO> Get(int id)
        {
            var project = _projectService.GetProjectById(id);
            return Ok(project);
        }

        [HttpPost]
        public ActionResult Add([FromBody] ProjectDTO projectDto)
        {
            _projectService.AddProject(projectDto);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] ProjectDTO projectDto)
        {
            _projectService.UpdateProject(projectDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _projectService.DeleteProject(id);
            return Ok();
        }

        [HttpPost("status")]
        public ActionResult ChangeStatus([FromBody] int id)
        {
            _projectService.ChangeStatus(id);
            return Ok();
        }
    }
}
