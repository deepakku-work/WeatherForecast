namespace TestApp.V1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNet.OData.Routing;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TestApp.Models.V1;

    [ApiVersion("1.0")]
    [ODataRoutePrefix("WeatherForecasts")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class WeatherForecastsController : BaseODataController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastsController> _logger;

        public WeatherForecastsController(ILogger<WeatherForecastsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ODataRoute]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
        public WeatherForecast CreateWeatherForecast()
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.Now.AddDays(Enumerable.Range(1, 5).First()),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }


        [HttpGet]
        [ODataRoute]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet]
        [ODataRoute("{id}")]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
        public WeatherForecast GetWeatherForecast(string id)
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Id = id,
                Date = DateTime.Now.AddDays(Enumerable.Range(1, 5).First()),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }
    }
}
