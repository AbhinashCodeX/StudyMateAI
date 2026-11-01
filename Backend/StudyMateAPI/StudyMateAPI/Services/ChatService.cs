using StudyMateAPI.Models;

namespace StudyMateAPI.Services
{
    public class ChatService : IChatService
    {
        private readonly IAiService _aiService;

        public ChatService(IAiService aiservice)
        {
            _aiService = aiservice;
        }
        public async Task<string> GetResponse(List<ChatMessage> messages)
        {
            return await _aiService.GetResponse(messages);
        }
    }
}
