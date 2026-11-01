
using StudyMateAPI.Models;

namespace StudyMateAPI.Services
{
    public interface IChatService
    {
        Task<string> GetResponse(List<ChatMessage> messages);
    }
}
