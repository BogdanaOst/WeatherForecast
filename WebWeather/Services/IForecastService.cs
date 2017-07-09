using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWeather.Models;

namespace WebWeather.Services
{
    public interface IForecastService
    {
        Forecast GetForecast(Parametrs parametrs);
    }
}
