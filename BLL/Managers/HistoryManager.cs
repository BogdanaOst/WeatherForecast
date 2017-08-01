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
       
        public async Task AddAsync(HistoryDTO historyDto)
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
            await Database.History.CreateAsync(model);
            await Database.SaveAsync();
           
        }
       
        public async Task<List<HistoryDTO>> GetAllAsync()
        {
           
            Mapper.Initialize(cfg => cfg.CreateMap<HistoryModel, HistoryDTO>());
            return Mapper.Map<List<HistoryModel>, List<HistoryDTO>>(await Database.History.GetAllAsync());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
       
    }
}
