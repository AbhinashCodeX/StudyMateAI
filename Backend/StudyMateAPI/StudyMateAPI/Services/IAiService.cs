namespace StudyMateAPI.Services
{
    public interface IAiService
    {
        Task<string> GetResponse(string message);
    }
}
