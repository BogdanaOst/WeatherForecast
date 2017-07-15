using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWeather.Models;
using WebWeather.Services;

namespace WebWeather.Tests
{
    [TestFixture]
    public class ForecastServiceTests
    {
        [Test]
        public void GetForecast_When_EmptyCity_Then_ReturnsNull()
        {
            var service = new ForecastService();
            var parametrs = new Parametrs() { CityName = "", NumOfDays = 1 };
            var result = service.GetForecast(parametrs);
            Assert.That(result, Is.EqualTo(null));
        }
        [Test]
        public void GetForecast_When_CityDoesntExist_Than_ReturnsNulll()
        {
            var service = new ForecastService();
            var parametrs = new Parametrs() { CityName = "eklsfdfijr234j8ds", NumOfDays = 1 };
            var result = service.GetForecast(parametrs);
            Assert.That(result, Is.EqualTo(null));
        }
    }
}
