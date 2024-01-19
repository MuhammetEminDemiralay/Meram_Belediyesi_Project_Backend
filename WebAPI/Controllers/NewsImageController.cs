using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsImageController : ControllerBase
    {
        INewsImageService _newsImageService;

        public NewsImageController(INewsImageService newsImageService)
        {
            _newsImageService = newsImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _newsImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getnewsimagebynewsıd")]
        public IActionResult GetNewsImageByNewsId(int newsId)
        {
            var result = _newsImageService.GetImagesByNewsId(newsId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile[] files, [FromForm] NewsImage newsImage)
        {
            var result = _newsImageService.AddCollective(files, newsImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(NewsImage newsImage)
        {
            var result = _newsImageService.Delete(newsImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
