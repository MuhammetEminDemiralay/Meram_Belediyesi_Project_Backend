using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCategoryController : ControllerBase
    {
        IProjectCategoryService _projectCategoryService;

        public ProjectCategoryController(IProjectCategoryService projectCategoryService)
        {
            _projectCategoryService = projectCategoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _projectCategoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getprojectcategorybyprojeccategorytid")]
        public IActionResult GetProjectCatgegoryDetailByProjectCategoryId(int projectId)
        {
            var result = _projectCategoryService.Get(projectId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(ProjectCategory projectCategory)
        {
            var result = _projectCategoryService.Add(projectCategory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(ProjectCategory projectCategory)
        {
            var result = _projectCategoryService.Update(projectCategory);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(ProjectCategory projectCategory)
        {
            var result = _projectCategoryService.Delete(projectCategory);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
