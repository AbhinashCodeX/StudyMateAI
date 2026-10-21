using Microsoft.AspNetCore.Mvc;
using StudyMateAPI.Models;
using StudyMateAPI.Services;

namespace StudyMateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("send")]
        public IActionResult SendMessage(ChatRequest request)
        {
            var response = _chatService.GetResponse(request.Message);
            return Ok(new
            {
                reply = response
            });
        }
    }
}
