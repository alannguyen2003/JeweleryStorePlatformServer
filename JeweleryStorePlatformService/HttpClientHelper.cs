using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class HttpClientHelper
    {
        private readonly HttpClient _httpClient;

        public HttpClientHelper()
        {
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = true
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://vapi.vnappmob.com")
            };
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if ((int)response.StatusCode >= 300 && (int)response.StatusCode < 400)
            {
                var newUrl = response.Headers.Location.ToString();
                response = await _httpClient.GetAsync(newUrl);
            }
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
