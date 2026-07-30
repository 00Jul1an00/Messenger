using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessagesService
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class MessageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MessageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return BadRequest("Сообщение не может быть пустым");
            }

            var messageEntity = new MessageEntity
            {
                Content = message,
                Timestamp = DateTime.UtcNow
            };

            _context.Messages.Add(messageEntity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _context.Messages.ToListAsync();
            return Ok(messages);
        }
    }
}