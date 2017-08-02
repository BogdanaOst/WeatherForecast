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
    public class CityService
    {
        string mainPath = $"http://localhost:{Localhost.port}/api/Cities/";

        public async Task<IEnumerable<CityModel>> GetSelected()
        {
           
            var client = new HttpClient();
            var response = client.GetAsync(mainPath).Result;
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<CityModel>>(result);

        }
        public async Task Add(string name)
        {
            var path = mainPath+"?name="+name;
            var client = new HttpClient();
            await client.PostAsync(path,null);
        }
        public async Task Delete(string name)
        {
            var path = mainPath + "?name=" + name;
            var client = new HttpClient();
            await client.DeleteAsync(path);
        }
    }
}
