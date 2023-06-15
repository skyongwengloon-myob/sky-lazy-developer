using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Helper
{
    public class ChatGpt
    {
        private readonly HttpClient _httpClient;
        private readonly string _openAiUrl = "https://api.openai.com/v1/engines/text-davinci-002/completions"; // replace with actual API URL
        private readonly string _apiKey = "API-KEY"; // replace with actual API key

        public ChatGpt()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetResponseAsync(string prompt)
        {
            var requestBody = new
            {
                prompt = prompt,
                temperature = 0.7f,
                max_tokens = 60,
                top_p = 1,
                frequency_penalty = 0,
                presence_penalty = 0
            };

            var jsonRequestBody = JsonConvert.SerializeObject(requestBody);
            var requestContent = new StringContent(jsonRequestBody);
            
            requestContent.Headers.Clear();
            requestContent.Headers.Add("Content-Type", "application/json");
            requestContent.Headers.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.PostAsync(_openAiUrl, requestContent);
            
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                dynamic responseJson = JsonConvert.DeserializeObject(responseBody);
                
                return responseJson;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"OpenAI GPT-3 API returned error status code: {response.StatusCode}. Error message: {errorResponse}");
            }
        }
    }
}