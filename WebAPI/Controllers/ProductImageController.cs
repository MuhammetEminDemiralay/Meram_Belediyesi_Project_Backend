using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        IProductImageService _productImageService;

        public ProductImageController(IProductImageService footballerImageService)
        {
            _productImageService = footballerImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result =_productImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getproductimagebyproductid")]
        public IActionResult GetProductImageByProductId(int productId)
        {
            var result = _productImageService.GetImagesByProductId(productId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile[] files, [FromForm] ProductImage productImage)
        {
            var result = _productImageService.AddCollective(files, productImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ProductImage productImage)
        {
            var result = _productImageService.Delete(productImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

    }
}
