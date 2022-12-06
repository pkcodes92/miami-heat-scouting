// <copyright file="ScoutingReportService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services
{
    using API.Data;
    using API.Data.Entities;
    using API.Services.Interfaces;
    using Microsoft.ApplicationInsights;

    /// <summary>
    /// This class will implement the methods defined in <see cref="IScoutingReportService"/>.
    /// </summary>
    public class ScoutingReportService : IScoutingReportService
    {
        private readonly TelemetryClient telemetryClient;
        private readonly ScoutContext scoutContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="telemetryClient"></param>
        /// <param name="scoutContext"></param>
        public ScoutingReportService(TelemetryClient telemetryClient, ScoutContext scoutContext)
        {
            this.telemetryClient = telemetryClient;
            this.scoutContext = scoutContext;
        }

        public async Task<ScoutingReport> InsertScoutingReport()
        {
            return null!;
        }
    }
}
