using AutoMapper;
using BLL.Managers;
using DAL.DTOs;
using DAL.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebWeather.Models;

namespace WebWeather.Api
{
    public class CitiesController : ApiController
    {
        ISelectedCityManager manager;
        public CitiesController()
        {
            manager = new SelectedCityManager(new UnitOfWork("DefaultConnection"));
        }

        public CitiesController(ISelectedCityManager imanager)
        {
            manager = imanager;
        }

        // GET api/Cities
        [HttpGet]
        public List<SelectedCityViewModel> GetAll()
        {
            List<SelectedCityDTO> citiesDtos = manager.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<SelectedCityDTO, SelectedCityViewModel>());
            var list = Mapper.Map<List<SelectedCityDTO>, List<SelectedCityViewModel>>(citiesDtos);
            return list;
        }

        // POST api/Cities/?name=CityName
        [HttpPost]
        public HttpResponseMessage Add(string name)
        {
            manager.Add(new SelectedCityDTO() { Name = name });
            return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
        }

        //DELETE api/Cities/id
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            if (manager.GetById(id) != null)
            {
                manager.Delete(id);
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
            } else
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };
            
        }

        //DELETE api/Cities/?name=CityName
        [HttpDelete]
        public HttpResponseMessage Delete(string name)
        {
            var item = manager.GetAll().FirstOrDefault(x => x.Name == name);
            if (item!= null)
            {
                manager.Delete(item.Id);
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
            }
            else
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };

        }
    }
}
