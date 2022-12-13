// <copyright file="GetAllPlayersResponse.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

#nullable disable

namespace API.Common.Models.Response
{
    using API.Common.DTO;
    using Newtonsoft.Json;

    /// <summary>
    /// This class models the response to get all the players.
    /// </summary>
    public class GetAllPlayersResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets a list of players.
        /// </summary>
        [JsonProperty("players")]
        public List<Player> Players { get; set; }
    }
}
