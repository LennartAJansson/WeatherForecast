namespace WeatherForecast.Db
{

    using global::WeatherForecast.Db.Abstract;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class WeatherForecastDbContextExtensions
    {
        public static IServiceCollection AddWeatherForecastDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IWeatherForecastService, WeatherForecastService>();
            services.AddDbContext<IWeatherForecastDbContext, WeatherForecastDbContext>(options =>
            options.UseSqlServer(connectionString));
            return services;
        }
    }
}