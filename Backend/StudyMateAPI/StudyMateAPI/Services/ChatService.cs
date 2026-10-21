namespace StudyMateAPI.Services
{
    public class ChatService : IChatService
    {
        public string GetResponse(string message)
        {
            return $"You asked: {message}";
        }
    }
}