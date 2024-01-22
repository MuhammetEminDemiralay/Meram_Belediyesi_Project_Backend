using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _projectService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getprojectbyprojectid")]
        public IActionResult GetProjectDetailByProjectId(int projectId)
        {
            var result = _projectService.GetProjectDetailByProjectId(projectId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getprojectbycategoryid")]
        public IActionResult GetProjectDetailByCategoryId(int categoryId)
        {
            var result = _projectService.GetProjectDetailByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Project project)
        {
            var result = _projectService.Add(project);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Project project)
        {
            var result = _projectService.Update(project);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Project project)
        {
            var result = _projectService.Delete(project);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
