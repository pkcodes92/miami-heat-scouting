// <copyright file="GetScoutingReportsByScoutResponse.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Common.Models.Response
{
    using API.Common.DTO;
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the response when getting all of the scouting reports by scout.
    /// </summary>
    public class GetScoutingReportsByScoutResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the necessary results.
        /// </summary>
        [JsonProperty("results")]
        public List<GroupScoutingResult> Results { get; set; } = null!;
    }
}
