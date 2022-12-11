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
        private readonly IPlayerService playerService;
        private readonly IScoutingReportRepository scoutingReportRepository;
        private readonly ITeamRepository teamRepository;
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoutingReportService"/> class.
        /// </summary>
        /// <param name="telemetryClient">The application insights injection.</param>
        /// <param name="scoutingReportRepository">The injection of the scouting report repository.</param>
        /// <param name="teamRepository">The injection of the team repository.</param>
        /// <param name="playerService">The player service injection.</param>
        /// <param name="userRepository">The user repository injection.</param>
        public ScoutingReportService(TelemetryClient telemetryClient, IScoutingReportRepository scoutingReportRepository, ITeamRepository teamRepository, IPlayerService playerService, IUserRepository userRepository)
        {
            this.telemetryClient = telemetryClient;
            this.scoutingReportRepository = scoutingReportRepository;
            this.teamRepository = teamRepository;
            this.playerService = playerService;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Inserts a new scouting report into the database.
        /// </summary>
        /// <param name="newScoutingReport">The incoming scouting report.</param>
        /// <returns>A unit of execution that contains a new scouting report.</returns>
        public async Task<int> InsertScoutingReportAsync(IncomingScoutingReport newScoutingReport)
        {
            this.telemetryClient.TrackTrace("Inserting a new scouting report");

            var user = await this.userRepository.GetUserByNameAsync(newScoutingReport.ScoutName);

            var player = await this.playerService.GetPlayerByFirstAndLastNameAsync(newScoutingReport.PlayerFirstName, newScoutingReport.PlayerLastName);

            var team = await this.teamRepository.GetTeamByNameAndCityAsync(newScoutingReport.TeamName, newScoutingReport.TeamCity);

            var scoutingReportToInsert = new Data.Entities.ScoutingReport
            {
                PlayerKey = (int)player?.PlayerId!,
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
        /// Retrieves all of the scouting reports.
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
                CreatedDateTime = x.Created,
                TeamKey = x.TeamKey,
                PlayerKey = x.PlayerKey,
            }).ToList();
        }

        /// <summary>
        /// Retrieves all of the scouting reports by scout ID.
        /// </summary>
        /// <param name="scoutId">The scout ID.</param>
        /// <returns>A list of scouting reports by scout ID.</returns>
        public async Task<List<GroupScoutingResult>> GetGroupedScoutingReportsByScoutAsync(string scoutId)
        {
            this.telemetryClient.TrackTrace($"Getting all the scouting reports belonging to: {scoutId}");

            // Get the necessary scouting reports by the scout first, and grouped by the team.
            var dbScoutingReports = await this.scoutingReportRepository.GetGroupedScoutingReportsAsync(scoutId);

            var scoutingReportGroupsToReturn = new List<GroupScoutingResult>();

            foreach (var item in dbScoutingReports)
            {
                // Getting the team information as the scouting reports are already grouped by the team.
                var teamInformation = await this.teamRepository.GetTeamByKeyAsync(item.Key);

                var groupedItem = new GroupScoutingResult
                {
                    TeamId = teamInformation.TeamKey,
                    NickName = teamInformation.TeamNickname!,
                    Conference = teamInformation.Conference!,
                    Players = await this.BuildPlayers(teamInformation, item.ToList()),
                };

                scoutingReportGroupsToReturn.Add(groupedItem);
            }

            return scoutingReportGroupsToReturn;
        }

        private async Task<List<GroupScoutingReport>> BuildReports(Data.Entities.Team teamInformation, Player playerInformation)
        {
            var dbScoutingReports = await this.scoutingReportRepository.GetScoutingReportByPlayerAndTeamAsync(teamInformation.TeamKey, playerInformation.PlayerId);

            var resultsToReturn = dbScoutingReports.Select(x => new GroupScoutingReport
            {
                Assist = x.Assist,
                Comments = x.Comments,
                CreatedDateTime = (DateTime)x.Created,
                Defense = x.Defense,
                IsActive = (bool)x.IsCurrent!,
                Rebound = x.Rebound,
                ScoutId = x.ScoutId,
                Shooting = x.Shooting,
            }).ToList();

            return resultsToReturn;
        }

        private async Task<List<GroupPlayer>> BuildPlayers(Data.Entities.Team teamInformation, List<Data.Entities.ScoutingReport> inputList)
        {
            var groupListToReturn = new List<GroupPlayer>();

            foreach (var item in inputList)
            {
                var playerInformation = await this.playerService.GetPlayerByKeyAsync(item.PlayerKey);

                this.telemetryClient.TrackTrace($"BuildPlayers called for the player: {playerInformation.GetFullName()} in {teamInformation.TeamCity} {teamInformation.TeamName}");

                var groupPlayerToAdd = new GroupPlayer
                {
                    PlayerId = playerInformation.PlayerId,
                    PlayerName = playerInformation.GetFullName(),
                    Dob = playerInformation.BirthDate,
                    ScoutingReports = await this.BuildReports(teamInformation, playerInformation),
                };

                groupListToReturn.Add(groupPlayerToAdd);
            }

            return groupListToReturn;
        }
    }
}
