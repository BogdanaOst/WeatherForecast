using AutoMapper;
using BLL.Infrastructure;
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
   public class SelectedCityManager:ISelectedCityManager
    {
        IUnitOfWork Database { get; set; }

        public SelectedCityManager(IUnitOfWork unit)
        {
            Database = unit;
        }

        public async Task AddAsync(SelectedCityDTO historyDto)
        {
            SelectedCity model = new SelectedCity()
            {
                Id = historyDto.Id,
                Name = historyDto.Name
            };
            await Database.SelectedCities.CreateAsync(model);
            await Database.SaveAsync();

        }
        public async Task<SelectedCityDTO> GetByIdAsync(int? id)
        {
            try
            {
                var cityDto = Database.SelectedCities.GetByIdAsync(id.Value);
                Mapper.Initialize(cfg => cfg.CreateMap<SelectedCity, SelectedCityDTO>());
                return Mapper.Map<SelectedCity, SelectedCityDTO>(await cityDto);
            }
            catch (Exception ex)
            {
                throw new ValidationException("Not found", "");
            }
        }
        public async Task<List<SelectedCityDTO>> GetAllAsync()
        {

            Mapper.Initialize(cfg => cfg.CreateMap<SelectedCity, SelectedCityDTO>());
            return Mapper.Map<List<SelectedCity>, List<SelectedCityDTO>>(await Database.SelectedCities.GetAllAsync());
        }

        public async Task Update(SelectedCityDTO city_dto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SelectedCityDTO, SelectedCity>());
            Database.SelectedCities.Update(Mapper.Map<SelectedCityDTO, SelectedCity>(city_dto));
           await Database.SaveAsync();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
        public async Task DeleteAsync(int id)
        {
            await Database.SelectedCities.DeleteAsync(id);
            await Database.SaveAsync();
        }
    }
}
