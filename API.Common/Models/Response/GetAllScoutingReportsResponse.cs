// <copyright file="GetAllScoutingReportsResponse.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Common.Models.Response
{
    using API.Common.DTO;
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the response for getting all the scouting reports accordingly.
    /// </summary>
    public class GetAllScoutingReportsResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the list of scouting reports.
        /// </summary>
        [JsonProperty("scoutingReports")]
        public List<ScoutingReport> ScoutingReports { get; set; } = null!;
    }
}
