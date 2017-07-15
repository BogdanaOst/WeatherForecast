using BLL.Managers;
using DAL.Entities;
using DAL.Repositories;
using DAL.UnitOfWork;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
            //Arrange & Act
            var controller = new HomeController().Index() as RedirectToRouteResult;
            //Assert
            Assert.AreEqual(controller.RouteValues["controller"], "Weather");
        }
       
     }
}
