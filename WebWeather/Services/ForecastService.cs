﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using WebWeather.Models;

namespace WebWeather.Services
{
    public class ForecastService
    {
       
        private Forecast forecast;
        
   
        public Forecast GetForecast(Parametrs parametrs)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string path = appSettings["BaseUrl"] + "q=" + parametrs.CityName + "&units=metric&cnt=" +parametrs.NumOfDays+"&APPID="+appSettings["ApiKey"];
            WebClient client = new WebClient();
            string jsonInfo = @"" + (client.DownloadString(path)).Replace('"', '\'');
            forecast = new Forecast(JsonConvert.DeserializeObject<RootObject>(jsonInfo));
            return forecast;
        }

    }
}