using AutoMapper;
using BLL.Managers;
using DAL.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebWeather.Models;

namespace WebWeather.Controllers
{
    public class SelectedCitiesController : Controller
    {
        ISelectedCityManager manager;
        public SelectedCitiesController(ISelectedCityManager imanager)
        {
            manager = imanager;
        }

        public async Task<ActionResult> Index()
        {
            List<SelectedCityDTO> citiesDtos = await manager.GetAllAsync();
            Mapper.Initialize(cfg => cfg.CreateMap<SelectedCityDTO, SelectedCityViewModel>());
            var result = Mapper.Map<List<SelectedCityDTO>, List<SelectedCityViewModel>>(citiesDtos);
            return View(result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(SelectedCityViewModel model)
        {
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(model.Name))
            {
                SelectedCityDTO cityDto = new SelectedCityDTO()
                {
                    Name = model.Name
                };
                await manager.AddAsync(cityDto);
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                SelectedCityDTO cityDto = await manager.GetByIdAsync(id);
                Mapper.Initialize(cfg => cfg.CreateMap<SelectedCityDTO, SelectedCityViewModel>());
                var res = Mapper.Map<SelectedCityDTO, SelectedCityViewModel>(cityDto);
                return View(res);
            }
            catch (ValidationException ex)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(SelectedCityViewModel model)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SelectedCityViewModel, SelectedCityDTO>());
            manager.Update(Mapper.Map<SelectedCityViewModel, SelectedCityDTO>(model));
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(int? id)
        {
            
            await manager.DeleteAsync(id.Value);
            return RedirectToAction("Index");
        }

    }
}