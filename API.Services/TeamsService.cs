// <copyright file="TeamsService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services
{
    using API.Common.DTO;
    using API.Data;
    using API.Data.Repository.Interfaces;
    using API.Services.Interfaces;
    using Microsoft.ApplicationInsights;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class implements the methods defined in <see cref="ITeamsService"/>.
    /// </summary>
    public class TeamsService : ITeamsService
    {
        private readonly TelemetryClient telemetryClient;
        private readonly ITeamRepository teamRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamsService"/> class.
        /// </summary>
        /// <param name="telemetryClient">The telemetry tracking injection.</param>
        /// <param name="teamRepository">The team repository injection.</param>
        public TeamsService(TelemetryClient telemetryClient, ITeamRepository teamRepository)
        {
            this.telemetryClient = telemetryClient;
            this.teamRepository = teamRepository;
        }

        /// <summary>
        /// Retrieves the active teams.
        /// </summary>
        /// <returns>The list of NBA teams.</returns>
        public async Task<List<Team>> GetActiveTeamsAsync()
        {
            this.telemetryClient.TrackTrace("TeamsService - GetActiveTeamsAsync called");
            List<Team> teamsToReturn;

            try
            {
                var dbTeams = await this.teamRepository.GetAllActiveTeamsAsync();
                teamsToReturn = dbTeams.Select(x => new Team
                {
                     CoachName = x.CoachName!,
                     Conference = x.Conference!,
                     Division = x.SubConference!,
                     TeamCity = x.TeamCity!,
                     TeamCountry = x.TeamCountry!,
                     TeamName = x.TeamName!,
                     TeamNickname = x.TeamNickname!,
                     TeamKey = x.TeamKey!,
                }).ToList();

                this.telemetryClient.TrackTrace($"Returned: {teamsToReturn.Count} results");
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackException(ex);
                teamsToReturn = null!;
            }

            return teamsToReturn;
        }

        /// <summary>
        /// Retrieves all teams in the database.
        /// </summary>
        /// <returns>A list of all the teams.</returns>
        public async Task<List<Team>> GetAllTeamsAsync()
        {
            this.telemetryClient.TrackTrace("TeamsService - GetAllTeamsAsync called");
            List<Team> teamsToReturn;

            try
            {
                var dbTeams = await this.teamRepository.GetAllTeamsAsync();
                teamsToReturn = dbTeams.Select(x => new Team
                {
                    CoachName = x.CoachName!,
                    Conference = x.Conference!,
                    Division = x.SubConference!,
                    TeamCity = x.TeamCity!,
                    TeamCountry = x.TeamCountry!,
                    TeamKey = x.TeamKey,
                    TeamName = x.TeamName!,
                    TeamNickname = x.TeamNickname!,
                }).ToList();

                this.telemetryClient.TrackTrace($"Returned {teamsToReturn.Count} teams");
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackException(ex);
                teamsToReturn = null!;
            }

            return teamsToReturn;
        }

        /// <summary>
        /// Retrieves a single team by looking up the primary key.
        /// </summary>
        /// <param name="teamKey">The primary key of the team entity.</param>
        /// <returns>A single team.</returns>
        public async Task<Team> GetTeamByKeyAsync(int teamKey)
        {
            Team teamToReturn;
            var dbTeam = await this.teamRepository.GetTeamByKeyAsync(teamKey);

            teamToReturn = new Team
            {
                CoachName = dbTeam.CoachName!,
                Conference = dbTeam.Conference!,
                Division = dbTeam.SubConference!,
                TeamCity = dbTeam.TeamCity!,
                TeamCountry = dbTeam.TeamCountry!,
                TeamKey = dbTeam.TeamKey,
                TeamName = dbTeam.TeamName!,
                TeamNickname = dbTeam.TeamNickname!,
            };

            return teamToReturn;
        }
    }
}
