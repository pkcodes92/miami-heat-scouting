// <copyright file="ScoutingReportService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>
namespace API.Services
{
    using API.Common.DTO;
    using API.Common.Models.Input;
    using API.Data;
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

            var player = await this.scoutContext.Players.FirstOrDefaultAsync(p => p.FirstName == newScoutingReport.PlayerFirstName &&
                p.LastName == newScoutingReport.PlayerLastName);

            // When I wrote the code this way for querying the team, it worked.
            // However, when I tried to write the code as above, it would not work.
            var team = await this.scoutContext.Teams.Where(t => t.TeamName == newScoutingReport.TeamName &&
                t.TeamCity == newScoutingReport.TeamCity &&
                t.CurrentNBATeamFlag == true).Select(x => new Team
                {
                    TeamKey = x.TeamKey,
                    CoachName = x.CoachName,
                    TeamName = x.TeamName,
                    Conference = x.Conference,
                    Division = x.SubConference,
                    TeamCity = x.TeamCity,
                    TeamCountry = x.TeamCountry,
                }).FirstOrDefaultAsync();

            var scoutingReportToInsert = new Data.Entities.ScoutingReport
            {
                PlayerKey = (int)player?.PlayerKey!,
                Assist = newScoutingReport.AssistRating,
                Comments = newScoutingReport.Comments,
                Defense = newScoutingReport.DefenseRating,
                Rebound = newScoutingReport.ReboundRating,
                Shooting = newScoutingReport.ShootingRating,
                Created = DateTime.Now,
                IsCurrent = true,
                ScoutId = user?.AzureAdUserId!,
                TeamKey = (int)team?.TeamKey!,
            };

            this.scoutContext.ScoutingReports.Add(scoutingReportToInsert);

            await this.scoutContext.SaveChangesAsync();

            return scoutingReportToInsert.ScoutingReportKey;
        }

        /// <summary>
        /// This method implementation gets all of the scouting reports in the database.
        /// </summary>
        /// <returns>A list of scouting reports to return to the API.</returns>
        public async Task<List<ScoutingReport>> GetAllScoutingReportsAsync()
        {
            this.telemetryClient.TrackTrace("Getting all the scouting reports");

            var scoutingReports = await this.scoutContext.ScoutingReports.Select(x => new ScoutingReport
            {
                ScoutId = x.ScoutId,
            }).ToListAsync();

            return scoutingReports;
        }
    }
}
