using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Admin_API.Infrastructure.FeedbackRepository
{
    public class ProfanityFilter
    {
        public async Task<string> OnPost(string feedback)
        {
            var client = new HttpClient();
            var body = "";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://neutrinoapi-bad-word-filter.p.rapidapi.com/bad-word-filter"),
                Headers =
    {
        { "x-rapidapi-host", "neutrinoapi-bad-word-filter.p.rapidapi.com" },
        { "x-rapidapi-key", "2e3bb4ec3bmshae001ecd1299e7ep1fc039jsna0c1456ba47c" },
    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "content", feedback },
        { "censor-character", "*" },
    }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"bodybody:: {body}");
            }
            return body;
        }
    }
}
