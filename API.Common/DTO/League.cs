// <copyright file="League.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

#nullable disable

namespace API.Common.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class models the league entity to return the information to the caller.
    /// </summary>
    public class League
    {
        /// <summary>
        /// Gets or sets a value indicating whether or not the league should display.
        /// </summary>
        [JsonProperty("displayFlag")]
        public bool DisplayFlag { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the league ID.
        /// </summary>
        [JsonProperty("leagueId")]
        public int LeagueId { get; set; }
    }
}
