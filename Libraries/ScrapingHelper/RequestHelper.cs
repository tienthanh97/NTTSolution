

namespace NTT.ScrapingLib.ScrapingHelper
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;

    public class RequestHelper
    {
        //  private AutoResetEvent _delay { get; set; }

        /// <summary>
        /// The HTTP client
        /// </summary>
        private HttpClient _httpClient;

        public RequestHelper()
        {
           // _delay = new AutoResetEvent(true);
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <returns></returns>
        public string GetDocument(string url,int interval=0)
        {
            var html = _httpClient.GetStringAsync(url);

            if (interval>0)
            {
                // _delay.WaitOne(interval);
                Delay(interval);
            }
           
            return html.Result;
        }
        /// <summary>
        /// Gets the document with header.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="headerConfigs">The header configs.</param>
        /// <param name="interval">The interval.</param>
        /// <returns></returns>
        public string GetDocumentWithHeader(string url,  Dictionary<string, string> headerConfigs, int interval = 0)
        {
            string html = "";
            using (_httpClient = new HttpClient())
            {
                var uri = new Uri(url);
                _httpClient.BaseAddress = uri;
                foreach (var entry in headerConfigs)
                {
                    _httpClient.DefaultRequestHeaders.Add(entry.Key, entry.Value);
                }
                var request = new HttpRequestMessage(HttpMethod.Get, "");
                var response = _httpClient.SendAsync(request).Result;
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    var result = content.ReadAsStringAsync().Result;

                    // ... Display the result.
                    if (result != null && result.Length > 0)
                    {
                        html = result;
                    }
                }
                Delay(interval);
            }
            return html;
        }


        /// <summary>
        /// Delays the specified interval.
        /// </summary>
        /// <param name="interval">The interval.</param>
        private void Delay(int interval)
        {
            Thread.Sleep(interval);
        }

       
    }
}


