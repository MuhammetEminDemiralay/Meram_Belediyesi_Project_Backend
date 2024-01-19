using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        IWorkService _workService;

        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _workService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getworkbyworkid")]
        public IActionResult GetWorkDetailByWorkId(int workId)
        {
            var result = _workService.Get(workId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Work work)
        {
            var result = _workService.Add(work);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Work work)
        {
            var result = _workService.Update(work);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Work work)
        {
            var result = _workService.Delete(work);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
