// <copyright file="GroupScoutingResult.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

#nullable disable

namespace API.Common.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the grouped scouting report result.
    /// </summary>
    public class GroupScoutingResult
    {
        /// <summary>
        /// Gets or sets the team key.
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets the nickname.
        /// </summary>
        [JsonProperty("nickName")]
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets the conference.
        /// </summary>
        [JsonProperty("conference")]
        public string Conference { get; set; }

        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        [JsonProperty("players")]
        public List<GroupPlayer> Players { get; set; }
    }
}
