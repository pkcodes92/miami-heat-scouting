// <copyright file="InsertScoutingReportResponse.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Common.Models.Response
{
    using Newtonsoft.Json;

    public class InsertScoutingReportResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the scouting report ID.
        /// </summary>
        [JsonProperty("scoutingReportId")]
        public int ScoutingReportId { get; set; }
    }
}