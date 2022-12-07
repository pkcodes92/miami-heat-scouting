// <copyright file="ScoutingReportService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>
namespace API.Services
{
    using API.Common.Models.Input;
    using API.Data;
    using API.Data.Entities;
    using API.Services.Interfaces;
    using Microsoft.ApplicationInsights;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class will implement the methods defined in <see cref="IScoutingReportService"/>.
    /// </summary>
    public class ScoutingReportService : IScoutingReportService
    {
        private readonly TelemetryClient telemetryClient;
        private readonly ScoutContext scoutContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoutingReportService"/> class.
        /// </summary>
        /// <param name="telemetryClient">The application insights injection.</param>
        /// <param name="scoutContext">The database layer injection.</param>
        public ScoutingReportService(TelemetryClient telemetryClient, ScoutContext scoutContext)
        {
            this.telemetryClient = telemetryClient;
            this.scoutContext = scoutContext;
        }

        /// <summary>
        /// This method implementation will add a new scouting report to the database.
        /// </summary>
        /// <param name="newScoutingReport">The incoming scouting report.</param>
        /// <returns>A unit of execution that contains a new scouting report.</returns>
        public async Task<int> InsertScoutingReportAsync(IncomingScoutingReport newScoutingReport)
        {
            this.telemetryClient.TrackTrace("Inserting a new scouting report");

            var user = await this.scoutContext.Users.FirstOrDefaultAsync(x => x.Name == newScoutingReport.ScoutName);

            var scoutingReportToInsert = new ScoutingReport
            {
                PlayerKey = 16,
                Assist = newScoutingReport.AssistRating,
                Comments = newScoutingReport.Comments,
                Defense = newScoutingReport.DefenseRating,
                Rebound = newScoutingReport.ReboundRating,
                Shooting = newScoutingReport.ShootingRating,
                Created = DateTime.Now,
                IsCurrent = true,
                ScoutId = user?.AzureAdUserId!,
                TeamKey = 16,
            };

            this.scoutContext.ScoutingReports.Add(scoutingReportToInsert);

            await this.scoutContext.SaveChangesAsync();

            return scoutingReportToInsert.ScoutingReportKey;
        }
    }
}
