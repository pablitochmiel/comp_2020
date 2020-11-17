using System;
using Xunit;
using App.Controllers;
using System.Collections;
using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using Utils;

namespace Test
{ 
    public class WeatherForecastControllerTest
    {
        private readonly string[] _list = {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};

        [Fact]
        public void WeatherForecastTest()
        {
            var weatherForecast = new WeatherForecast{Date = DateTime.Today, Summary = "Freezing", TemperatureC = 10};
            Assert.Equal(DateTime.Today,weatherForecast.Date);
            Assert.Equal("Freezing",weatherForecast.Summary);
            Assert.Equal(10,weatherForecast.TemperatureC);
            Assert.Equal(32 + (int) (10 / 0.5556),weatherForecast.TemperatureF);
        } 
        
        [Fact]
        public void LogTest()
        {
            var mock = new Mock<ILogger<WeatherForecastController>>();
            var weatherForecast = new WeatherForecastController(mock.Object);
            weatherForecast.Get();

            mock.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(), 
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString() == "test"),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)));
        }
        
        [Fact]
        public void GetTest()
        {
            var mock = new Mock<ILogger<WeatherForecastController>>();
            var weatherForecast = new WeatherForecastController(mock.Object);
            var temp=weatherForecast.Get().ToList();
            Assert.Equal(5, temp.Count);

            var i = 1;
            foreach (var item in temp)
            {
                Assert.Equal(DateTime.Today.AddDays(i).Day, item.Date.Day);
                Assert.InRange(item.TemperatureC, -20, 55);
                Assert.Contains(item.Summary, _list);
                i++;
            }
        }
    }
}