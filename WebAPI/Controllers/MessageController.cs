using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _messageService.GetMessagesDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getallmessagesbyuserıd")]
        public IActionResult GetAllMessagesByUserId(int userId)
        {
            var result = _messageService.GetMessageDetailByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getmessage")]
        public IActionResult GetMessageByMessageId(int messageId)
        {
            var result = _messageService.GetMessageDetail(messageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("add")]
        public IActionResult Add(Message message)
        {
            var result = _messageService.Add(message);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Message message)
        {
            var result = _messageService.Update(message);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Message message)
        {
            var result = _messageService.Delete(message);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
