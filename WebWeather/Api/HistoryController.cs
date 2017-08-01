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

namespace WebWeather.Api
{
    public class HistoryController : ApiController
    {

        IHistoryManager service;

        public HistoryController(IHistoryManager service)
        {
            this.service = service;
        }

       
        //GET api/History/
        [HttpGet]
        public async Task<List<HistoryViewModel>> GetAll()
        {
            List<HistoryDTO> historyDtos = await service.GetAllAsync();
            Mapper.Initialize(cfg => cfg.CreateMap<HistoryDTO, HistoryViewModel>());
            var history = Mapper.Map<List<HistoryDTO>, List<HistoryViewModel>>(historyDtos);
            return history;
        }
    }
}
