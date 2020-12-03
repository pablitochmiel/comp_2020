using System;
using System.Threading.Tasks;

namespace Blazor.Data
{
    public interface IWeatherForecastService
    {
        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}