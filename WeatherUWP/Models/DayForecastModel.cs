using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherUWP.Models
{
    public class DayForecastModel
    {
        public double DayTemp { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
        public double Pressure { get; set; }
        public string Icon { get; set; }
        public string Date { get; set; }
    }
}
