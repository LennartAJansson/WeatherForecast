namespace WeatherForecast.Controllers
{
    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Mediators.WeatherForecastResponse>? result = await mediator.Send(new Mediators.GetWeatherForecasts());

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetByDate(DateTimeOffset date) => Ok(await mediator.Send(new Mediators.GetWeatherForecast(date)));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Mediators.AddWeatherForecast weatherForecast) => Ok(await mediator.Send(weatherForecast));
    }
}