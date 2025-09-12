using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Nion.App.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient()
        {
            _http = new HttpClient { BaseAddress = new Uri("http://192.168.0.200/") };
        }

        public async Task<T?> PostAsync<T>(string url, object data)
        {
            try
            {

                var response = await _http.PostAsJsonAsync(url, data);
                if (!response.IsSuccessStatusCode) return default;
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
