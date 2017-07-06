using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebWeather.Models;

namespace WebWeather.Services
{
    public class Deserializator
    {
        public Forecast Get(Parametrs parametrs)
        {
            
             string path = "http://api.openweathermap.org/data/2.5/forecast/daily?q=" + parametrs.city+"&units=metric&APPID=030e0de55deb68d47090aec778996d58";

                 WebClient client = new WebClient();
            try
            {
                string jsonInfo = @"" + (client.DownloadString(path)).Replace('"', '\'');

                Forecast forecast = new Forecast(JsonConvert.DeserializeObject<RootObject>(jsonInfo));
                forecast.SetDays(parametrs.numOfDays);
                return forecast;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}