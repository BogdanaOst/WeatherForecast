using BLL.Managers;
using DAL.Entities;
using DAL.Repositories;
using DAL.UnitOfWork;
using FakeItEasy;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebWeather.Controllers;

namespace WebWeather.Tests.ManagersTests
{
    public class SelectedCityTests
    {
        [Test]
        public async Task Create_When_NewCityAdded_UoWSaveIsCalled()
        {
            var city = new SelectedCity()
            {
                Id = 1,
                Name = "SomeName"
            };

            var citiesRepository = A.Fake<IRepository<SelectedCity>>();
            A.CallTo(() => citiesRepository.GetAllAsync()).Returns(new List<SelectedCity>() { city });
            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.SelectedCities).Returns(citiesRepository);
            var service = new SelectedCityManager(unitOfWork);
            await service.AddAsync(new DAL.DTOs.SelectedCityDTO() { Id = city.Id, Name = city.Name });
            A.CallTo(() => unitOfWork.SaveAsync()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public async Task Create_When_EmptyCity_Then_ModelNotValid()
        {
            var citiesRepository = A.Fake<IRepository<SelectedCity>>();
            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.SelectedCities).Returns(citiesRepository);
            var manager = new SelectedCityManager(unitOfWork);

            var controller = new SelectedCitiesController(manager);
            await controller.Create(new Models.SelectedCityViewModel() { Id = 1, Name = "" });
            Assert.That((await citiesRepository.GetAllAsync()).Count == 0);
        }
        [Test]
        public async Task Delete_When_IdIsNull_Then_Nothing()
        {
            var citiesRepository = A.Fake<IRepository<SelectedCity>>();
            A.CallTo(() => citiesRepository.GetAllAsync()).Returns(new List<SelectedCity>());
            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.SelectedCities).Returns(citiesRepository);
            var service = new SelectedCityManager(unitOfWork);
            await service.DeleteAsync(0);
            Assert.Pass();
        }

        [Test]
        public async Task Create_Works()
        {
            var city = new SelectedCity()
            {
                Id = 1,
                Name = "SomeName"
            };

            var citiesRepository = A.Fake<IRepository<SelectedCity>>();
            A.CallTo(() => citiesRepository.GetAllAsync()).Returns(new List<SelectedCity>() { city });
            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.SelectedCities).Returns(citiesRepository);
            var service = new SelectedCityManager(unitOfWork);
            await service.AddAsync(new DAL.DTOs.SelectedCityDTO() { Id = city.Id, Name = city.Name });
            Assert.AreEqual((await citiesRepository.GetAllAsync()).Count, 1);
        }
    }
}