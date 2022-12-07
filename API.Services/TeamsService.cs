// <copyright file="TeamsService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services
{
    using API.Common;
    using API.Common.DTO;
    using API.Data;
    using API.Services.Interfaces;
    using Microsoft.ApplicationInsights;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class implements the methods defined in <see cref="ITeamsService"/>.
    /// </summary>
    public class TeamsService : ITeamsService
    {
        private readonly ScoutContext scoutContext;
        private readonly TelemetryClient telemetryClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamsService"/> class.
        /// </summary>
        /// <param name="scoutContext">The database layer being injected.</param>
        /// <param name="telemetryClient">The telemetry tracking injection.</param>
        public TeamsService(ScoutContext scoutContext, TelemetryClient telemetryClient)
        {
            this.scoutContext = scoutContext;
            this.telemetryClient = telemetryClient;
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
                teamsToReturn = await this.scoutContext.Teams.Where(x => x.CurrentNBATeamFlag == true).Select(x => new Team
                {
                    CoachName = x.CoachName,
                    Conference = x.Conference,
                    Division = x.SubConference,
                    TeamName = x.TeamName,
                    TeamNickname = x.TeamNickname,
                    TeamCity = x.TeamCity,
                    TeamCountry = x.TeamCountry,
                    TeamKey = x.TeamKey,
                }).ToListAsync();
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
                teamsToReturn = await this.scoutContext.Teams.Select(x => new Team
                {
                    CoachName = x.CoachName,
                    Conference = x.Conference,
                    Division = x.SubConference,
                    TeamName = x.TeamName,
                    TeamNickname = x.TeamNickname,
                    TeamCity = x.TeamCity,
                    TeamCountry = x.TeamCountry,
                    TeamKey = x.TeamKey,
                }).ToListAsync();
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
