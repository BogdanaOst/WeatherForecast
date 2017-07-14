using BLL.Managers;
using DAL.Entities;
using DAL.Repositories;
using DAL.UnitOfWork;
using FakeItEasy;
using NUnit.Framework;
using System.Collections.Generic;
using WebWeather.Controllers;

namespace WebWeather.Tests.IntegrationTests
{
    public class SelectedCityTests
    {
        [Test]
        public void Create_When_NewCityAdded_UoWSaveIsCalled()
        {
            var city = new SelectedCity()
            {
                Id = 1,
                Name = "SomeName"
            };

            var citiesRepository = A.Fake<IRepository<SelectedCity>>();
            A.CallTo(() => citiesRepository.GetAll()).Returns(new List<SelectedCity>() { city });
            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.SelectedCities).Returns(citiesRepository);
            var service = new SelectedCityManager(unitOfWork);
            service.Add(new DAL.DTOs.SelectedCityDTO() { Id = city.Id, Name = city.Name });
            A.CallTo(() => unitOfWork.Save()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Create_When_EmptyCity_Then_ModelNotValid()
        {
            var citiesRepository = A.Fake<IRepository<SelectedCity>>();
            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.SelectedCities).Returns(citiesRepository);
            var manager = new SelectedCityManager(unitOfWork);

            var controller = new SelectedCitiesController(manager);
            controller.Create(new Models.SelectedCityViewModel() { Id = 1, Name = "" });
            Assert.That(citiesRepository.GetAll().Count == 0);
        }
    }
}
