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

namespace WebWeather.Tests.IntegrationTests
{
    [TestFixture]
    public class HistoryTests
    {
        [Test]
        public void GetAll_When_NoInit_Then_EmptyListButNotNull()
        {
            var historyRepository = A.Fake<IRepository<HistoryModel>>();
            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.History).Returns(historyRepository);

            var historyService = new HistoryManager(unitOfWork);
            Assert.NotNull(historyService.GetAll());
            Assert.IsEmpty(historyService.GetAll());
        }
    }
}
