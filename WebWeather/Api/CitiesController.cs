using AutoMapper;
using BLL.Managers;
using DAL.DTOs;
using DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebWeather.Models;

namespace WebWeather.Api
{
    public class CitiesController : ApiController
    {
       private ISelectedCityManager manager;
     
        public CitiesController(ISelectedCityManager imanager)
        {
            manager = imanager;
        }

        // GET api/Cities
        [HttpGet]
        public async Task<List<SelectedCityViewModel>> GetAll()
        {
            List<SelectedCityDTO> citiesDtos = await manager.GetAllAsync();
            Mapper.Initialize(cfg => cfg.CreateMap<SelectedCityDTO, SelectedCityViewModel>());
            var list = Mapper.Map<List<SelectedCityDTO>, List<SelectedCityViewModel>>(citiesDtos);
            return list;
        }

        // POST api/Cities/?name=CityName
        [HttpPost]
        public async Task<HttpResponseMessage> Add(string name)
        {
            await manager.AddAsync(new SelectedCityDTO() { Name = name });
            return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
        }

        //DELETE api/Cities/id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            if (manager.GetByIdAsync(id) != null)
            {
                await manager.DeleteAsync(id);
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
            } else
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };
            
        }

        //DELETE api/Cities/?name=CityName
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(string name)
        {
            var item = (await manager.GetAllAsync()).FirstOrDefault(x => x.Name == name);
            if (item!= null)
            {
                await manager.DeleteAsync(item.Id);
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
            }
            else
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };

        }
    }
}
