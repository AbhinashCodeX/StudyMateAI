using StudyMateAPI.Models;

namespace StudyMateAPI.Services
{
    public interface IAiService
    {
        Task<string> GetResponse(List<ChatMessage> messages);
    }
}
