// <copyright file="ScoutingReport.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

#nullable disable

namespace API.Common.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class will get the necessary scouting report.
    /// </summary>
    public class ScoutingReport
    {
        /// <summary>
        /// Gets or sets the scout ID.
        /// </summary>
        [JsonProperty("scoutId")]
        public string ScoutId { get; set; }

        /// <summary>
        /// Gets or sets the assist rating.
        /// </summary>
        [JsonProperty("assist")]
        public int Assist { get; set; }

        /// <summary>
        /// Gets or sets the defensive rating.
        /// </summary>
        [JsonProperty("defense")]
        public int Defense { get; set; }

        /// <summary>
        /// Gets or sets the shooting rating.
        /// </summary>
        [JsonProperty("shooting")]
        public int Shooting { get; set; }

        /// <summary>
        /// Gets or sets the rebounding rating.
        /// </summary>
        [JsonProperty("rebound")]
        public int Rebound { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if the scouting report is active.
        /// </summary>
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date/time that the scouting report has been created.
        /// </summary>
        [JsonProperty("createdDateTime")]
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the player key.
        /// </summary>
        [JsonProperty("playerKey")]
        public int PlayerKey { get; set; }

        /// <summary>
        /// Gets or sets the team key.
        /// </summary>
        [JsonProperty("teamKey")]
        public int TeamKey { get; set; }
    }
}
