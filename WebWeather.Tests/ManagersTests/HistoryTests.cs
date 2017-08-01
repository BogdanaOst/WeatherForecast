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

namespace WebWeather.Tests.ManagersTests
{
    [TestFixture]
    public class HistoryTests
    {
        [Test]
        public async Task GetAll_When_NoInit_Then_EmptyListButNotNull()
        {
            //Arrange
            var historyRepository = A.Fake<IRepository<HistoryModel>>();
            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.History).Returns(historyRepository);
            //Act
            var historyService = new HistoryManager(unitOfWork);
            //Assert
            Assert.NotNull(await historyService.GetAllAsync());
            Assert.IsEmpty(await historyService.GetAllAsync());
        }
    }
}
