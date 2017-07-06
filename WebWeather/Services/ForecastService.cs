using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebWeather.Models;

namespace WebWeather.Services
{
    public class ForecastService
    {
       
        private Forecast forecast;
        
        public ForecastService(Parametrs parametrs)
        {
            
            Deserializator deserial = new Deserializator();
            forecast = deserial.Get(parametrs);

        }

        public Forecast GetForecast()
        {
            return forecast;
        }

    }
}