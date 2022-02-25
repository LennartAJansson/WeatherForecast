namespace WeatherForecast.Mediators
{
    using System.Reflection;

    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    public static class WeatherForecastMediatorExtensions
    {
        public static IServiceCollection AddWeatherForecastMediators(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetAssembly(typeof(GetWeatherForecast)) ?? throw new NullReferenceException());
            return services;
        }
    }
}