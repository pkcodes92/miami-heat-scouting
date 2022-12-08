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
        /// This method returns a list of all the active teams.
        /// </summary>
        /// <returns>The list of NBA teams.</returns>
        public async Task<List<Team>> GetActiveTeamsAsync()
        {
            List<Team> teamsToReturn;

            try
            {
                var dbTeams = await this.teamRepository.GetAllActiveTeamsAsync();
                teamsToReturn = dbTeams.Select(x => new Team
                {
                     CoachName = x.CoachName,
                     Conference = x.Conference,
                     Division = x.SubConference,
                     TeamCity = x.TeamCity,
                     TeamCountry = x.TeamCountry,
                     TeamKey = x.TeamKey,
                     TeamName = x.TeamName,
                     TeamNickname = x.TeamNickname,
                }).ToList();
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackException(ex);
                teamsToReturn = null!;
            }

            return teamsToReturn;
        }

        /// <summary>
        /// This method implementation returns all of the teams in the database.
        /// </summary>
        /// <returns>A list of all the teams.</returns>
        public async Task<List<Team>> GetAllTeamsAsync()
        {
            List<Team> teamsToReturn;

            try
            {
                var dbTeams = await this.teamRepository.GetAllTeamsAsync();
                teamsToReturn = dbTeams.Select(x => new Team
                {
                    CoachName = x.CoachName,
                    Conference = x.Conference,
                    Division = x.SubConference,
                    TeamCity = x.TeamCity,
                    TeamCountry = x.TeamCountry,
                    TeamKey = x.TeamKey,
                    TeamName = x.TeamName,
                    TeamNickname = x.TeamNickname,
                }).ToList();
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackException(ex);
                teamsToReturn = null!;
            }

            return teamsToReturn;
        }
    }
}
