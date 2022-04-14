using Microsoft.Extensions.Configuration;
using NewsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Services
{
    public class ApiService : IApiService
    {
        private readonly string _apiKey;
        public ApiService()
        {
            _apiKey = Credentials.ApiKey;
        }
        public async Task<Root> GetNews(string category)
        {
            var httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?token={_apiKey}&lang=en&topic={category.ToLower()}");
            var dto = JsonConvert.DeserializeObject<Root>(res);
            return dto;
        }
    }
}
