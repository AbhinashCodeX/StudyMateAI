namespace StudyMateAPI.Services
{
    public interface IChatService
    {
        Task<string> GetResponse(string message);
    }
}
