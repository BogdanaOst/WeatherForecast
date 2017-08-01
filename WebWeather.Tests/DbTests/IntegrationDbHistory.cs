using BLL.Managers;
using DAL.Context;
using DAL.UnitOfWork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebWeather.Controllers;
using WebWeather.Models;
using WebWeather.Services;

namespace WebWeather.Tests.DbTests
{
    [TestFixture]
    public class IntegrationDbHistory
    {
        HistoryController controller;
        IHistoryManager manager;
        IUnitOfWork unit;
        AppContext context;

        [SetUp]
        public void SetUp()
        {
            unit = new UnitOfWork("Tests");
            context = new AppContext("Tests");
            manager = new HistoryManager(unit);
            controller = new HistoryController(manager);
        }

        [Test]
        public void When_GetAllFromController_Then_ListsAreEqual()
        {
            //Arrange & Act
            var result = controller.Index().Result as ViewResult;
            //Assert
            Assert.AreEqual(context.History.Count(), (result.Model as IEnumerable<HistoryViewModel>).Count());
        }
      
        [TearDown]
        public void TearDown()
        {
            context.History.RemoveRange(context.History);
            context.SaveChanges();
        }
    }
}
