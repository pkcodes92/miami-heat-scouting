// <copyright file="WeatherForecast.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API
{
    /// <summary>
    /// This class models a sample Weather forecast model.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the temperature in degrees Centigrade.
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Gets the temperature in degrees Fahrenheit.
        /// </summary>
        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string? Summary { get; set; }
    }
}
