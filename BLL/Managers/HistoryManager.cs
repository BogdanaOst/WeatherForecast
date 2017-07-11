using AutoMapper;
using DAL.Context;
using DAL.DTOs;
using DAL.Entities;
using DAL.Repositories;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class HistoryManager:IHistoryManager
    {
        IUnitOfWork Database { get; set; }

        public HistoryManager(IUnitOfWork unit)
        {
            Database = unit;
        }
       
        public void Add(HistoryDTO historyDto)
        {
            HistoryModel model = new HistoryModel()
            {
                Id = historyDto.Id,
                City=historyDto.City,
                Date = historyDto.Date,
                DayTemp = historyDto.DayTemp,
                NumOfDaysRequested = historyDto.NumOfDaysRequested,
                Icon=historyDto.Icon
            };
            Database.History.Create(model);
            Database.Save();
           
        }
       
        public List<HistoryDTO> GetAll()
        {
           
            Mapper.Initialize(cfg => cfg.CreateMap<HistoryModel, HistoryDTO>());
            return Mapper.Map<List<HistoryModel>, List<HistoryDTO>>(Database.History.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
       
    }
}
