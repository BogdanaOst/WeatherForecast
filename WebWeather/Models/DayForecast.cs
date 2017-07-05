using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebWeather.Models
{
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
    }

    public class Temp
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double night { get; set; }
        public double eve { get; set; }
        public double morn { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class List
    {
        public int dt { get; set; }
        public Temp temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public List<Weather> weather { get; set; }
        public double speed { get; set; }
        public int deg { get; set; }
        public int clouds { get; set; }
        public double? rain { get; set; }
    }

    public class RootObject
    {
        public City city { get; set; }
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<List> list { get; set; }
    }

    public class DayForecast
    {
        public double morningTemp { get; set; }
        public double eveningTemp { get; set; }
        public double dayTemp { get; set; }
        public double nightTemp { get; set; }
        public bool rain { get; set; }
        public double pressure { get; set; }
        public string icon { get; set; }
        public string date { get; set; }
    }
    public class Forecast
    {
        List<DayForecast> forecast=new List<DayForecast>();
        public string city { get; private set; }
        public Forecast(RootObject obj)
        {
            city = obj.city.name;
            int i = 0;
            foreach(var d in obj.list)
            {
                DayForecast dayF = new DayForecast()
                {
                    dayTemp = d.temp.day,
                    morningTemp = d.temp.morn,
                    eveningTemp = d.temp.eve,
                    nightTemp = d.temp.night,
                    rain = d.rain > 0.5,
                    pressure = d.pressure,
                    icon = "http://openweathermap.org/img/w/" + d.weather.FirstOrDefault().icon + ".png",
                    date = DateTime.Now.AddDays(i).ToShortDateString()
                };
                forecast.Add(dayF);
                i++;
            }
        }
        public void SetDays(int days)
        {
            forecast = forecast.GetRange(0,days);
        }
        public List<DayForecast> GetDailyList()
        {
            return forecast;
        }
    }
}