// <copyright file="GroupPlayer.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

#nullable disable

namespace API.Common.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the group player within the scouting report group result.
    /// </summary>
    public class GroupPlayer
    {
        /// <summary>
        /// Gets or sets the player ID.
        /// </summary>
        [JsonProperty("playerId")]
        public int PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        [JsonProperty("dob")]
        public DateTime? Dob { get; set; }

        /// <summary>
        /// Gets or sets the player name.
        /// </summary>
        [JsonProperty("playerName")]
        public string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets the scouting reports.
        /// </summary>
        [JsonProperty("scoutingReports")]
        public List<GroupScoutingReport> ScoutingReports { get; set; }
    }
}