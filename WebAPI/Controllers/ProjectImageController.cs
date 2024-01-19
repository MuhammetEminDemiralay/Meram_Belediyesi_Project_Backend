using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectImageController : ControllerBase
    {
        IProjectImageService _projectImageService;

        public ProjectImageController(IProjectImageService projectImageService)
        {
            _projectImageService = projectImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _projectImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getprojectimagebyprojectid")]
        public IActionResult GetProjectImageByProjectId(int projectId)
        {
            var result = _projectImageService.GetImagesByProjectId(projectId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile[] files, [FromForm] ProjectImage projectImage)
        {
            var result = _projectImageService.AddCollective(files, projectImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ProjectImage projectImage)
        {
            var result = _projectImageService.Delete(projectImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
