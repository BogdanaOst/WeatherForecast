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
        private Forecast forecast;

        // GET: Weather
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Parametrs parametrs)
        {
            if (!string.IsNullOrWhiteSpace(parametrs.city))
            {
                ForecastService service = new ForecastService(parametrs.city, parametrs.numOfDays);
                forecast = service.GetForecast();

                return View(forecast);
            }
            else
                return View();
        }
        public ActionResult OtherCity()
        {
           
            return View(forecast);
        }
    }
}