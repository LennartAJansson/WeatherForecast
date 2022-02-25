namespace WeatherForecast.Db.Abstract
{
    using Microsoft.EntityFrameworkCore;

    public interface IWeatherForecastDbContext
    {
        DbSet<WeatherForecast> WeatherForecasts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}