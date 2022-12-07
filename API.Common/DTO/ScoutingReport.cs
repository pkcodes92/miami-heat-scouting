// <copyright file="ScoutingReport.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace API.Common.DTO
{
    /// <summary>
    /// This class will get the necessary scouting report.
    /// </summary>
    public class ScoutingReport
    {
        /// <summary>
        /// Gets or sets the scout ID.
        /// </summary>
        [JsonProperty("scoutId")]
        public string ScoutId { get; set; } = null!;

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
        public string Comments { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating if the scouting report is active.
        /// </summary>
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
