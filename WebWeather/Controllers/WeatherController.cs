using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebWeather.Models;
using WebWeather.Services;

namespace WebWeather.Controllers
{
    public class WeatherController : Controller
    {

        IForecastService service;
        static Forecast forecast;

        public WeatherController(IForecastService iservice)
        {
            service = iservice;
        }

        // GET: Weather
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(Parametrs parametrs)
        {
            if (!string.IsNullOrWhiteSpace(parametrs.CityName))
            {
                forecast = service.GetForecast(parametrs);
            }
            else if(forecast!=null) forecast = service.GetForecast(new Parametrs() { CityName = forecast.City, NumOfDays = parametrs.NumOfDays });
                return View(forecast);
        }
        public ActionResult OtherCity()
        {
           
            return View(forecast);
        }
    }
}