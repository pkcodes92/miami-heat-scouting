// <copyright file="ScoutingReportController.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Controllers
{
    using API.Data.Entities;
    using API.Services.Interfaces;
    using Microsoft.ApplicationInsights;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This controller will have all the API methods for the <see cref="ScoutingReport"/> entity.
    /// </summary>
    [ApiController]
    [Route("Scout")]
    public class ScoutingReportController : ControllerBase
    {
        private readonly TelemetryClient telemetryClient;
        private readonly IScoutingReportService scoutingReportService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoutingReportController"/> class.
        /// </summary>
        /// <param name="telemetryClient">The telemetry client injection.</param>
        /// <param name="scoutingReportService">The scouting report service injection.</param>
        public ScoutingReportController(TelemetryClient telemetryClient, IScoutingReportService scoutingReportService)
        {
            this.telemetryClient = telemetryClient;
            this.scoutingReportService = scoutingReportService;
        }
    }
}
