using BLL.Managers;
using DAL.Context;
using DAL.UnitOfWork;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using WebWeather.Controllers;
using WebWeather.Models;

namespace WebWeather.Tests.DbTests
{
    [TestFixture]
    public class IntegrationDbSelectedCitiesTests
    {
        SelectedCitiesController controller;
        ISelectedCityManager manager;
        IUnitOfWork unit;
        AppContext context;

        [SetUp]
        public void SetUp()
        {
            unit = new UnitOfWork("Tests");
            context = new AppContext("Tests");
            manager = new SelectedCityManager(unit);
            controller = new SelectedCitiesController(manager);
        }

        [Test]
        public async Task When_CreateFromControllerValid_Then_AddsToDb()
        {
            //Arrange
            var city = new SelectedCityViewModel() { Id = 1, Name = "Kharkiv" };
            //Act
            await controller.Create(city);
            //Assert
            Assert.AreEqual(1, context.SelectedCities.Count());
        }

        [Test]
        public async Task When_CreateFromControllerInvallidModel_Then_DoesntAddToDb()
        {
            //Arrange & Act
            await controller.Create(new SelectedCityViewModel());
            //Assert
            Assert.AreEqual(0, context.SelectedCities.Count());
        }

        [Test]
        public async Task When_DeleteByCorrectId_Then_DbUpdates()
        {
            //Arrange
            var city = new SelectedCityViewModel() { Id = 1, Name = "Kharkiv" };
            await controller.Create(city);
            //Act
            await controller.Delete(context.SelectedCities.FirstOrDefault(x=>x.Name== "Kharkiv").Id);
            context.SaveChanges();
            //Assert
            Assert.AreEqual(0, context.SelectedCities.Count());
        }

        [Test]
        public void When_DeleteByIncorrectId_Then_DbDoesntCange()
        {
            //Arrange
            var city = new SelectedCityViewModel() { Id = 1, Name = "Kharkiv" };
            controller.Create(city);
            //Act
            controller.Delete(100);
            context.SaveChanges();
            //Assert
            Assert.AreEqual(1, context.SelectedCities.Count());
        }
       
        [TearDown]
        public void TearDown()
        {
            context.SelectedCities.RemoveRange(context.SelectedCities);
            context.SaveChanges();
        }
    }

  
}
