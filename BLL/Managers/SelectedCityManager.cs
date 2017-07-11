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

        public void Add(SelectedCityDTO historyDto)
        {
            SelectedCity model = new SelectedCity()
            {
                Id = historyDto.Id,
                Name = historyDto.Name
            };
            Database.SelectedCities.Create(model);
            Database.Save();

        }
        public SelectedCityDTO GetById(int? id)
        {
            try
            {
                var cityDto = Database.SelectedCities.GetById(id.Value);
                Mapper.Initialize(cfg => cfg.CreateMap<SelectedCity, SelectedCityDTO>());
                return Mapper.Map<SelectedCity, SelectedCityDTO>(cityDto);
            }
            catch (Exception ex)
            {
                throw new ValidationException("Not found", "");
            }
        }
        public List<SelectedCityDTO> GetAll()
        {

            Mapper.Initialize(cfg => cfg.CreateMap<SelectedCity, SelectedCityDTO>());
            return Mapper.Map<List<SelectedCity>, List<SelectedCityDTO>>(Database.SelectedCities.GetAll());
        }

        public void Update(SelectedCityDTO city_dto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SelectedCityDTO, SelectedCity>());
            Database.SelectedCities.Update(Mapper.Map<SelectedCityDTO, SelectedCity>(city_dto));
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
        public void Delete(int id)
        {
            Database.SelectedCities.Delete(id);
            Database.Save();
        }
    }
}
