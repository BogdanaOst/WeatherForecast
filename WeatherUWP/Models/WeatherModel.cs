using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherUWP.Models
{
    public class WeatherModel
    {
        public List<DayForecastModel> forecast { get; set; }
        public string City { get; set; }
    }
}
