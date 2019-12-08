

namespace RealEstateWorker.Engines
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class ApiHandler
    {
        private HttpClient _client;

        public string Response { get; set; }

        public ApiHandler(string baseAddress)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseAddress);
        }

        public async Task<string> SendPost(string content,string url)
        {
            var result = await _client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
            return await result.Content.ReadAsStringAsync();
        }
    
        public async Task<string> SendGet(string url)
        {
            
            var result = await _client.GetAsync(url);
            return await result.Content.ReadAsStringAsync();
        }

    }
}
