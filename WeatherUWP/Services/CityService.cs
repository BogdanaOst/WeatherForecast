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
        public IEnumerable<CityModel> GetSelected()
        {
            var path = "http://localhost:59721/api/Cities";
            var client = new HttpClient();
            var response = client.GetAsync(path).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IEnumerable<CityModel>>(result);

        }
        public async void Add(string name)
        {
            var path = "http://localhost:59721/api/Cities/?name="+name;
            var client = new HttpClient();
            await client.PostAsync(path,null);
        }
        public async void Delete(string name)
        {
            var path = "http://localhost:59721/api/Cities/?name=" + name;
            var client = new HttpClient();
            await client.DeleteAsync(path);
        }
    }
}
