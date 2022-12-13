// <copyright file="GetAllLeaguesResponse.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

#nullable disable

namespace API.Common.Models.Response
{
    using API.Common.DTO;
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the league model which will be returned to the caller.
    /// </summary>
    public class GetAllLeaguesResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the list of all the leagues.
        /// </summary>
        [JsonProperty("league")]
        public List<League> Leagues { get; set; }
    }
}
