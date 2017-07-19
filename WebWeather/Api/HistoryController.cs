using AutoMapper;
using BLL.Managers;
using DAL.DTOs;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebWeather.Models;

namespace WebWeather.Api
{
    public class HistoryController : ApiController
    {

        IHistoryManager service;

        public HistoryController(IHistoryManager service)
        {
            this.service = service;
        }

        public HistoryController()
        {
            service = new HistoryManager(new UnitOfWork("DefaultConnection"));
        }

        //GET api/History/
        [HttpGet]
        public List<HistoryViewModel> GetAll()
        {
            List<HistoryDTO> historyDtos = service.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<HistoryDTO, HistoryViewModel>());
            var history = Mapper.Map<List<HistoryDTO>, List<HistoryViewModel>>(historyDtos);
            return history;
        }
    }
}
