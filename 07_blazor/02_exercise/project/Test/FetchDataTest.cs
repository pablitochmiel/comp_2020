using System;
using Blazor.Data;
using Blazor.Pages;
using Xunit;

namespace Test
{
    public class FetchDataTest
    {
        [Fact]
        public void Test1()
        {
            var temp = new FetchData();
            //Assert.NotNull(temp.Forecasts);
            Assert.Empty(temp.Forecasts ?? Array.Empty<WeatherForecast>());
            

        }
    }
}