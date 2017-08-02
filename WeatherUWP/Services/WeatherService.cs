using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherUWP.Models;

namespace WeatherUWP.Services
{
    public class WeatherService
    {
        public async Task<WeatherModel> GetForesect(string city, int NumOfDays)
        {
            var path = $"http://localhost:{Localhost.port}/api/Forecast/?name={city}&days={NumOfDays}";
            var client = new HttpClient();
            var response = await client.GetAsync(path);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WeatherModel>(result);
            
        }
    }
}
