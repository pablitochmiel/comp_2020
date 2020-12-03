using System;
using Blazor.Data;
using Xunit;

namespace Test
{
    public class DataTest
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
        public void WeatherServiceTest()
        {
            var service = new WeatherForecastService();

            var result = service.GetForecastAsync(DateTime.Now).Result;
            var i = 1;
            foreach (var item in result)
            {
                var date = DateTime.Now;
                date = date.AddDays(i);
                Assert.IsType<WeatherForecast>(item);
                Assert.InRange(item.TemperatureC, -20, 55);
                Assert.InRange(item.TemperatureF, -4, 131);
                Assert.Contains(item.Summary, _list);
                Assert.Equal(date.DayOfYear, item.Date.DayOfYear);
                i++;
            }
        }
    
    }
}