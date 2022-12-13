// <copyright file="IncomingScoutingReport.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

#nullable disable

namespace API.Common.Models.Input
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents an incoming scouting report.
    /// </summary>
    public class IncomingScoutingReport
    {
        /// <summary>
        /// Gets or sets the name of the scout.
        /// </summary>
        [JsonProperty("scoutName")]
        public string ScoutName { get; set; }

        /// <summary>
        /// Gets or sets the team city.
        /// </summary>
        [JsonProperty("teamCity")]
        public string TeamCity { get; set; }

        /// <summary>
        /// Gets or sets the team name.
        /// </summary>
        [JsonProperty("teamName")]
        public string TeamName { get; set; }

        /// <summary>
        /// Gets or sets the player first name.
        /// </summary>
        [JsonProperty("playerFirstName")]
        public string PlayerFirstName { get; set; }

        /// <summary>
        /// Gets or sets the player last name.
        /// </summary>
        [JsonProperty("playerLastName")]
        public string PlayerLastName { get; set; }

        /// <summary>
        /// Gets or sets the shooting rating.
        /// </summary>
        [JsonProperty("shootingRating")]
        public int ShootingRating { get; set; }

        /// <summary>
        /// Gets or sets the defensive rating.
        /// </summary>
        [JsonProperty("defenseRating")]
        public int DefenseRating { get; set; }

        /// <summary>
        /// Gets or sets the assist rating.
        /// </summary>
        [JsonProperty("assistRating")]
        public int AssistRating { get; set; }

        /// <summary>
        /// Gets or sets the rebound rating.
        /// </summary>
        [JsonProperty("reboundRating")]
        public int ReboundRating { get; set; }

        /// <summary>
        /// Gets or sets the necessary comments.
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }
    }
}