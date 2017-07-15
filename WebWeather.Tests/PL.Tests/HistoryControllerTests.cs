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
using WebWeather.Models;

namespace WebWeather.Tests.PL.Tests
{
    [TestFixture]
    public class HistoryControllerTests
    {
        IHistoryManager service;
        List<HistoryModel> Data = new List<HistoryModel>();
        [SetUp]
        public void SetUp()
        {
            var historyRepository = A.Fake<IRepository<HistoryModel>>();
            A.CallTo(() => historyRepository.GetAll()).Returns(Data);
            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.History).Returns(historyRepository);
            service = new HistoryManager(unitOfWork);
        }
        [Test]
        public void Index_ReturnsCorrectType()
        {
            Data.Add(new HistoryModel());
            var controller = new HistoryController(service);
            var res = controller.Index() as ViewResult;
            Assert.AreEqual(typeof(List<HistoryViewModel>), res.Model.GetType());
        }
        [Test]
        public void Index_When_ListIsEmpty_Then_NoExc()
        {
            
            var controller = new HistoryController(service);
            controller.Index();
            Assert.Pass();
        }
    }
}
