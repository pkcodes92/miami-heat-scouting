// <copyright file="SearchPlayerResponse.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Common.Models.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the response when searching for a player.
    /// </summary>
    public class SearchPlayerResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the player name.
        /// </summary>
        [JsonProperty("playerName")]
        public string PlayerName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the team name that the player is on.
        /// </summary>
        [JsonProperty("teamName")]
        public string TeamName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the season.
        /// </summary>
        [JsonProperty("season")]
        public int Season { get; set; }
    }
}
