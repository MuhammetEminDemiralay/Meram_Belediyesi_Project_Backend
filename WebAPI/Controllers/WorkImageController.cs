using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkImageController : ControllerBase
    {
        IWorkImageService _workImageService;

        public WorkImageController(IWorkImageService workImageService)
        {
            _workImageService = workImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _workImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getworkimagebyworkıd")]
        public IActionResult GetWorkImageByWorkId(int workId)
        {
            var result = _workImageService.GetImagesByWorkId(workId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile[] files, [FromForm] WorkImage workImage)
        {
            var result = _workImageService.AddCollective(files, workImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(WorkImage workImage)
        {
            var result = _workImageService.Delete(workImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(IFormFile file, [FromForm] WorkImage workImage)
        {
            var result = _workImageService.Update(file, workImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
