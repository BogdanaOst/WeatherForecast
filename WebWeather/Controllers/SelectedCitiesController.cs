using AutoMapper;
using BLL.Managers;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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

        public ActionResult Index()
        {
            List<SelectedCityDTO> citiesDtos = manager.GetAll();
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
        public ActionResult Create(SelectedCityViewModel model)
        {
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(model.Name))
            {
                SelectedCityDTO cityDto = new SelectedCityDTO()
                {
                    Name = model.Name
                };
                manager.Add(cityDto);
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                SelectedCityDTO cityDto = manager.GetById(id);
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
        public ActionResult Delete(int? id)
        {
            
            manager.Delete(id.Value);
            return RedirectToAction("Index");
        }

    }
}