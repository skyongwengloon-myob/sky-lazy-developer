using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Helper
{
    public class GptService
    {
        private readonly string _apiKey;
        private readonly string _model;
        private readonly Uri _uri = new Uri("https://api.openai.com/v1/engines/davinci-codex/completions");

        public GptService(string apiKey, string model)
        {
            _apiKey = apiKey;
            _model = model;
        }

        public async Task<string[]> GenerateResponseAsync(string prompt)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

                var request = new
                {
                    prompt = prompt,
                    max_tokens = 150,
                    temperature = 0.7,
                    n = 1,
                    stop = "\n"
                };

                var requestBody = JsonConvert.SerializeObject(request);
                var response = await client.PostAsync(_uri, new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(responseBody);

                string[] choices = new string[result.choices.Count];
                for (int i = 0; i < result.choices.Count; i++)
                {
                    choices[i] = result.choices[i].text.ToString();
                }

                return choices;
            }
        }
    }
}