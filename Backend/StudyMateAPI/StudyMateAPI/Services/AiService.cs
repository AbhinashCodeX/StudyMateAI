
using System.Net.Http.Json;
using StudyMateAPI.Models;

namespace StudyMateAPI.Services
{
    public class AiService : IAiService
    {
        private readonly HttpClient _httpClient;

        public AiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetResponse(List<ChatMessage> messages)
        {
            var request = new
            {
                model = "llama3.2:1b",
                messages = messages.Select(m => new
                {
                    role = m.Role,
                    content = m.Content
                }).ToList(),
                stream = false
            };

            var response = await _httpClient.PostAsJsonAsync(
                "api/chat", request);

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadFromJsonAsync<OllamaChatResponse>();

            return result?.Message?.Content
                ?? "Sorry, I couldn't generate a response.";
        }
    }

    public class OllamaChatResponse
    {
        public OllamaMessage? Message { get; set; }
    }

    public class OllamaMessage
    {
        public string Role { get; set; } = "";
        public string Content { get; set; } = "";
    }
}
