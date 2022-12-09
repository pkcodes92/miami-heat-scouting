// <copyright file="InsertScoutingReportResponse.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Common.Models.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the response after a new scouting report is inserted into the database.
    /// </summary>
    public class InsertScoutingReportResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the scouting report ID.
        /// </summary>
        [JsonProperty("scoutingReportId")]
        public int ScoutingReportId { get; set; }
    }
}