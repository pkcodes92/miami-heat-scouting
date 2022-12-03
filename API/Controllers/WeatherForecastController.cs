// <copyright file="WeatherForecastController.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This is a default controller to get the weather forecast details.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching",
        };

        private readonly ILogger<WeatherForecastController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="logger">The logging mechanism.</param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// This method returns a list of forecasts.
        /// </summary>
        /// <returns>A type of <see cref="IEnumerable{T}"/> where the type is <seealso cref="WeatherForecast"/>.</returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            })
            .ToArray();
        }
    }
}