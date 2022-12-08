// <copyright file="GetTeamsResponse.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Common.Models.Response
{
    using Newtonsoft.Json;
    using API.Common.DTO;

    /// <summary>
    /// This class represents the response for getting the teams.
    /// </summary>
    public class GetTeamsResponse : ApiResponse
    {
        [JsonProperty("teams")]
        public List<Team> Teams { get; set; } = null!;
    }
}
