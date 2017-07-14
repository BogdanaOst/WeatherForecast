using BLL.Managers;
using DAL.Entities;
using DAL.Repositories;
using DAL.UnitOfWork;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebWeather.Controllers;

namespace WebWeather.Tests.PL.Tests
{
    [TestFixture]
    public class HistoryControllerTests
    {
        [Test]
        public void Index_When_ListIsEmpty_Then_NoExc()
        {

            var historyRepository = A.Fake<IRepository<HistoryModel>>();
            A.CallTo(() => historyRepository.GetAll()).Returns(new List<HistoryModel>());
            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.History).Returns(historyRepository);
            var service = new HistoryManager(unitOfWork);
            var controller = new HistoryController(service);
            controller.Index();
            Assert.Pass();
        }
    }
}
