namespace WeatherForecast.Mediators
{

    using MediatR;

    public record GetWeatherForecast(DateTimeOffset Date) : IRequest<WeatherForecastResponse>;
    public record GetWeatherForecasts() : IRequest<IEnumerable<WeatherForecastResponse>>;
    public record AddWeatherForecast(DateTimeOffset Date, int Temperature, bool IsCelsius, string? Summary) : IRequest<WeatherForecastResponse>;

    public record WeatherForecastResponse(DateTimeOffset Date, int TemperatureC, int TemperatureF, string? Summary);
}