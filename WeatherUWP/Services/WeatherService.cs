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
    public class WeatherService
    {
        public async Task<WeatherModel> GetForesect(string city, int NumOfDays)
        {
            var path = "http://localhost:59721/api/Forecast/?name=" + city + "&days=" + NumOfDays;
            var client = new HttpClient();
            var response = await client.GetAsync(path);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WeatherModel>(result);
            
        }
    }
}
