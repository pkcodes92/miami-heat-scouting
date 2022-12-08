// <copyright file="ScoutingReportService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>
namespace API.Services
{
    using API.Common.DTO;
    using API.Common.Models.Input;
    using API.Data.Repository.Interfaces;
    using API.Services.Interfaces;
    using Microsoft.ApplicationInsights;

    /// <summary>
    /// This class will implement the methods defined in <see cref="IScoutingReportService"/>.
    /// </summary>
    public class ScoutingReportService : IScoutingReportService
    {
        private readonly TelemetryClient telemetryClient;
        private readonly IPlayerRepository playerRepository;
        private readonly IScoutingReportRepository scoutingReportRepository;
        private readonly ITeamRepository teamRepository;
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoutingReportService"/> class.
        /// </summary>
        /// <param name="telemetryClient">The application insights injection.</param>
        /// <param name="scoutingReportRepository">The injection of the scouting report repository.</param>
        /// <param name="teamRepository">The injection of the team repository.</param>
        /// <param name="playerRepository">The player repository injection.</param>
        /// <param name="userRepository">The user repository injection.</param>
        public ScoutingReportService(TelemetryClient telemetryClient, IScoutingReportRepository scoutingReportRepository, ITeamRepository teamRepository, IPlayerRepository playerRepository, IUserRepository userRepository)
        {
            this.telemetryClient = telemetryClient;
            this.scoutingReportRepository = scoutingReportRepository;
            this.teamRepository = teamRepository;
            this.playerRepository = playerRepository;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// This method implementation will add a new scouting report to the database.
        /// </summary>
        /// <param name="newScoutingReport">The incoming scouting report.</param>
        /// <returns>A unit of execution that contains a new scouting report.</returns>
        public async Task<int> InsertScoutingReportAsync(IncomingScoutingReport newScoutingReport)
        {
            this.telemetryClient.TrackTrace("Inserting a new scouting report");

            var user = await this.userRepository.GetUserByNameAsync(newScoutingReport.ScoutName);

            var player = await this.playerRepository.GetPlayerByFirstAndLastNameAsync(newScoutingReport.PlayerFirstName, newScoutingReport.PlayerLastName);

            var team = await this.teamRepository.GetTeamByNameAndCityAsync(newScoutingReport.TeamName, newScoutingReport.TeamCity);

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

            var insertedId = await this.scoutingReportRepository.InsertScoutingReportAsync(scoutingReportToInsert);

            return insertedId;
        }

        /// <summary>
        /// This method implementation gets all of the scouting reports in the database.
        /// </summary>
        /// <returns>A list of scouting reports to return to the API.</returns>
        public async Task<List<ScoutingReport>> GetAllScoutingReportsAsync()
        {
            this.telemetryClient.TrackTrace("Getting all the scouting reports");
            var dbScoutingReports = await this.scoutingReportRepository.GetAllScoutingReportsAsync();

            return dbScoutingReports.Select(x => new ScoutingReport
            {
                Assist = x.Assist,
                Comments = x.Comments,
                Defense = x.Defense,
                Rebound = x.Rebound,
                IsActive = (bool)x.IsCurrent!,
                ScoutId = x.ScoutId,
                Shooting = x.Shooting,
            }).ToList();
        }
    }
}
