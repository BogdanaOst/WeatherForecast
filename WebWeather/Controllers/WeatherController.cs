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
                
                Forecast forecast = service.GetForecast(parametrs);
                return View(forecast);
            }
            else
                return View();
        }
        public ActionResult OtherCity()
        {
           
            return View();
        }
    }
}