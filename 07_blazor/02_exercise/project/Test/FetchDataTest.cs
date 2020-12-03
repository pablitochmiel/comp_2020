using System;
using System.Collections.Generic;
using Blazor.Data;
using Blazor.Pages;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Components.Testing;
using Moq;
using Xunit;

namespace Test
{
    public class FetchDataTest
    {
        private readonly TestHost _host = new TestHost();
        private readonly string[] _listSummaries = {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};

        
        [Fact]
        public void NullTest()
        {
            var mock = new Mock<IWeatherForecastService>();
            mock.Setup(s => s.GetForecastAsync(It.IsAny<DateTime>())).ReturnsAsync((WeatherForecast[]) null!);
            _host.AddService(mock.Object);
            var component = _host.AddComponent<FetchData>();
            Assert.Contains("Loading...", component.GetMarkup());
        }

        [Fact]
        public void NotNullTest()
        {
            _host.AddService((IWeatherForecastService)new WeatherForecastService());
            var list =new List<HtmlNode>( _host.AddComponent<FetchData>().FindAll("td"));
            var j = 1;
            for (var i = 0; i < list.Count; j++)
            {
                Assert.Equal(DateTime.Now.AddDays(j).ToString("d"),list[i++].InnerHtml);
                Assert.InRange(int.Parse(list[i++].InnerHtml),-20,55);
                Assert.InRange(int.Parse(list[i++].InnerHtml),-4,131);
                Assert.Contains(list[i++].InnerHtml, _listSummaries);
            }
            
        }
    }
}