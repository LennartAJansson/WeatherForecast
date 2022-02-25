namespace WeatherForecast.Db
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using global::WeatherForecast.Db.Abstract;

    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastDbContext context;

        public WeatherForecastService(IWeatherForecastDbContext context) => this.context = context;

        public Task<WeatherForecast> GetWeatherForecastAsync(DateTimeOffset date) =>
            Task.FromResult(context.WeatherForecasts.SingleOrDefault(x => x.Date == date));

        public Task<List<WeatherForecast>> GetWeatherForecastsAsync() =>
            Task.FromResult(context.WeatherForecasts.ToList());
        public async Task<WeatherForecast> AddWeatherForecastAsync(WeatherForecast forecast)
        {
            context.WeatherForecasts.Add(forecast);
            await context.SaveChangesAsync();
            return forecast;
        }
    }
}