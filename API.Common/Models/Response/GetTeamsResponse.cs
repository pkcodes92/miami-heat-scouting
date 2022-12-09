// <copyright file="GetTeamsResponse.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Common.Models.Response
{
    using API.Common.DTO;
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the response for getting the teams.
    /// </summary>
    public class GetTeamsResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the list of teams to return to the caller.
        /// </summary>
        [JsonProperty("teams")]
        public List<Team> Teams { get; set; } = null!;
    }
}
