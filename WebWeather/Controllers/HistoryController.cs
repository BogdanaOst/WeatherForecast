using AutoMapper;
using BLL.Managers;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebWeather.Models;

namespace WebWeather.Controllers
{
    public class HistoryController : Controller
    {
        IHistoryManager service;
        
        public HistoryController(IHistoryManager service)
        {
            this.service = service;
        }

        public async Task<ActionResult> Index()
        {
            var historyDtos = await service.GetAllAsync();
            Mapper.Initialize(cfg => cfg.CreateMap<HistoryDTO, HistoryViewModel>());
            var history = Mapper.Map<List<HistoryDTO>, List<HistoryViewModel>>(historyDtos);
            history.Reverse();
            return  View( history.GetRange(0,Math.Min(10,history.Count)));
        }
    }
}