namespace WeatherForecast.Db.Abstract
{
    public interface IWeatherForecastService
    {
        Task<List<WeatherForecast>> GetWeatherForecastsAsync();
        Task<WeatherForecast> GetWeatherForecastAsync(DateTimeOffset date);
        Task<WeatherForecast> AddWeatherForecastAsync(WeatherForecast forecast);
    }
}