using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherUWP.Models;

namespace WeatherUWP.Services
{
    public class HistoryService
    {
        public async Task<IEnumerable<HistoryModel>> Get()
        {
            var path = "http://localhost:59721/api/History";
            var client = new HttpClient();
            var response = client.GetAsync(path).Result;
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<HistoryModel>>(result);
        }
    }
}
