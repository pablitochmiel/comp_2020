using Microsoft.EntityFrameworkCore;
using Utils;

namespace App
{
    public class WeatherForecastContext: DbContext
    {
        public DbSet<WeatherForecast>? WeatherForecasts { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=forecast.db");
        }
    }
}