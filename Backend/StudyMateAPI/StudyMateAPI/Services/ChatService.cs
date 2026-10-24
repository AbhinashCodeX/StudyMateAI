namespace StudyMateAPI.Services
{
    public class ChatService : IChatService
    {
        private readonly IAiService _aiService;

        public ChatService(IAiService aiservice)
        {
            _aiService = aiservice;
        }
        public async Task<string> GetResponse(string message)
        {
            return await _aiService.GetResponse(message);
        }
    }
}