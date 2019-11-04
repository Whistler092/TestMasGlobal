using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestMasGlobal.Entities;

namespace TestMasGlobal.Core.Data
{
    public abstract class ApiClient
    {  
        private readonly HttpClient _httpClient;  
        public Uri BaseEndpoint { get; set; }  
  
        protected ApiClient(Uri baseEndpoint)  
        {  
            if (baseEndpoint == null)  
            {  
                throw new ArgumentNullException("baseEndpoint");  
            }  
            BaseEndpoint = baseEndpoint;  
            _httpClient = new HttpClient();  
        }
        public async Task<T> GetAsync<T>(Uri requestUrl)  
        {    
            var response = 
                await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);  
            response.EnsureSuccessStatusCode();  
            var data = await response.Content.ReadAsStringAsync();  
            return JsonConvert.DeserializeObject<T>(data);  
        } 
    }
}
