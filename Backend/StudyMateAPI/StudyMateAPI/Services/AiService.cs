using System.Net.Http.Json;

namespace StudyMateAPI.Services
{
    public class AiService : IAiService
    {
        private readonly HttpClient _httpClient;

        public AiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetResponse(string message)
        {
            var request = new
            {
                model = "llama3.2:1b",
                prompt = message,
                stream = false
            };

            var response = await _httpClient.PostAsJsonAsync("api/generate",request);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<OllamaResponse>();

            return result?.Response ?? "Sorry, I couldn't generate a response.";
        }
    }

    public class OllamaResponse
    {
        public string Response { get; set; } = "";
    }
}