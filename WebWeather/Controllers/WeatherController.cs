using AutoMapper;
using BLL.Managers;
using DAL.DTOs;
using System.Web.Mvc;
using WebWeather.Models;
using WebWeather.Services;

namespace WebWeather.Controllers
{
    public class WeatherController : Controller
    {

        IForecastService forecastService;
        IHistoryManager historyManager;

        static Forecast forecast;

        public WeatherController(IForecastService iservice, IHistoryManager ihistoryManager)
        {
            forecastService = iservice;
            historyManager = ihistoryManager;
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
                forecast = forecastService.GetForecast(parametrs);
            }
            else if (forecast != null)
            
                forecast = forecastService.GetForecast(new Parametrs() { CityName = forecast.City, NumOfDays = parametrs.NumOfDays });

                HistoryViewModel model = new HistoryViewModel()
                {
                    City = forecast.City,
                    NumOfDaysRequested = parametrs.NumOfDays,
                    Date = forecast.GetDailyList()[0].Date,
                    DayTemp = forecast.GetDailyList()[0].DayTemp,
                    Icon = forecast.GetDailyList()[0].Icon
                };

                Mapper.Initialize(cfg => cfg.CreateMap<HistoryViewModel, HistoryDTO>());
                var historyDto = Mapper.Map<HistoryViewModel, HistoryDTO>(model);
                historyManager.Add(historyDto);
            
            return View(forecast);
        }
        public ActionResult OtherCity()
        {
           
            return View(forecast);
        }
    }
}