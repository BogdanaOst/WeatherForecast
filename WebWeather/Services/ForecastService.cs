using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebWeather.Models;

namespace WebWeather.Services
{
    public class ForecastService
    {
        private string city;
        private int numOfDays;
        private Forecast forecast;
        
        public ForecastService(string city, int days)
        {
            this.city = city;
            numOfDays = days;
            Deserializator deserial = new Deserializator();
            forecast = deserial.Get(city,days);

        }

        public Forecast GetForecast()
        {
            return forecast;
        }

    }
}