using BLL.Managers;
using DAL.UnitOfWork;
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
    public class RedirectsTest
    {
        [Test]
        public void When_Home_Then_RedirectToWeather()
        {
            var controller = new HomeController().Index() as RedirectToRouteResult;
            Assert.AreEqual(controller.RouteValues["controller"], "Weather");
        }

     }
}
