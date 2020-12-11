using System;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable All
namespace Spa
{
    [ExcludeFromCodeCoverage]
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}