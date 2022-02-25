namespace WeatherForecast.Mediators
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    public class WeatherForecastMediator : IRequestHandler<GetWeatherForecast, WeatherForecastResponse>,
        IRequestHandler<GetWeatherForecasts, IEnumerable<WeatherForecastResponse>>,
        IRequestHandler<AddWeatherForecast, WeatherForecastResponse>
    {
        private readonly Db.Abstract.IWeatherForecastService service;

        public WeatherForecastMediator(Db.Abstract.IWeatherForecastService service) => this.service = service;
        public async Task<WeatherForecastResponse> Handle(GetWeatherForecast request, CancellationToken cancellationToken)
        {
            WeatherForecast? result = await service.GetWeatherForecastAsync(request.Date);
            return new WeatherForecastResponse(result.Date, result.TemperatureC, result.TemperatureF, result.Summary);
        }

        public async Task<IEnumerable<WeatherForecastResponse>> Handle(GetWeatherForecasts request, CancellationToken cancellationToken)
        {
            List<WeatherForecast>? result = await service.GetWeatherForecastsAsync();
            return result.Select(w => new WeatherForecastResponse(w.Date, w.TemperatureC, w.TemperatureF, w.Summary));
        }

        public async Task<WeatherForecastResponse> Handle(AddWeatherForecast request, CancellationToken cancellationToken)
        {
            WeatherForecast? forecast = new WeatherForecast
            {
                Date = request.Date,
                TemperatureC = request.IsCelsius ? request.Temperature : (request.Temperature - 32) * 5 / 9,
                Summary = request.Summary
            };
            WeatherForecast? result = await service.AddWeatherForecastAsync(forecast);
            return new WeatherForecastResponse(result.Date, result.TemperatureC, result.TemperatureF, result.Summary);
        }
    }
}