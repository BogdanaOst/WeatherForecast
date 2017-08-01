using AutoMapper;
using BLL.Managers;
using DAL.DTOs;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebWeather.Models;
using WebWeather.Services;

namespace WebWeather.Api
{
    public class ForecastController : ApiController
    {
        //GET api/Forecast/?name=CityName&days=NumOfDays

        [HttpGet]
        public async Task<Forecast> GetForecast (string name,int days)
        {
            ForecastService service = new ForecastService();
            var forecast= service.GetForecast(new Parametrs() { NumOfDays = days, CityName = name });
            if(forecast!=null)
            {
                var history = new HistoryManager(new UnitOfWork("DefaultConnection"));
                HistoryViewModel model = new HistoryViewModel()
                {
                    City = forecast.City,
                    NumOfDaysRequested = days,
                    Date = forecast.GetDailyList()[0].Date,
                    DayTemp = forecast.GetDailyList()[0].DayTemp,
                    Icon = forecast.GetDailyList()[0].Icon
                };


                Mapper.Initialize(cfg => cfg.CreateMap<HistoryViewModel, HistoryDTO>());
                var historyDto = Mapper.Map<HistoryViewModel, HistoryDTO>(model);
                await history.AddAsync(historyDto);
            }

            return forecast;
        }
    }
}
