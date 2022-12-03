// <copyright file="TeamController.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Controllers
{
    using API.Data;
    using API.Entities;
    using Microsoft.ApplicationInsights;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class represents all of the CRUD operations to be performed with the <see cref="Team"/> model.
    /// </summary>
    [ApiController]
    [Route("Team")]
    public class TeamController : ControllerBase
    {
        private readonly TelemetryClient telemetryClient;
        private readonly ScoutContext scoutContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamController"/> class.
        /// </summary>
        /// <param name="telemetryClient">Microsoft Application Insights injection.</param>
        /// <param name="scoutContext">The database layer being injected.</param>
        public TeamController(TelemetryClient telemetryClient, ScoutContext scoutContext)
        {
            this.telemetryClient = telemetryClient;
            this.scoutContext = scoutContext;
        }

        /// <summary>
        /// This method gets all of the active teams from the database.
        /// </summary>
        /// <returns>A list of the teams.</returns>
        [HttpGet]
        [Route("GetActiveTeams")]
        public async Task<ActionResult<List<Team>>> GetActiveTeamsAsync()
        {
            List<Team> teams;

            try
            {
                teams = await this.scoutContext.Teams.Where(x => x.CurrentNBATeamFlag == true).Select(x => new Team
                {
                    TeamKey = x.TeamKey,
                    ArenaKey = x.ArenaKey,
                    CoachName = x.CoachName,
                    Conference = x.Conference,
                    CurrentNBATeamFlag = x.CurrentNBATeamFlag,
                    LeagueKey = x.LeagueKey,
                    SubConference = x.SubConference,
                    TeamCity = x.TeamCity,
                    TeamCountry = x.TeamCountry,
                    TeamName = x.TeamName,
                    TeamNickname = x.TeamNickname,
                    URLPhoto = x.URLPhoto,
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackTrace($"Error occurred while getting the active teams: {ex.Message}");
                teams = null!;
            }

            return teams;
        }

        /// <summary>
        /// This method gets all the teams accordingly.
        /// </summary>
        /// <returns>Returns all the teams from the database.</returns>
        [HttpGet]
        [Route("GetAllTeams")]
        public async Task<ActionResult<List<Team>>> GetAllTeamsAsync()
        {
            List<Team> teams;

            try
            {
                teams = await this.scoutContext.Teams.Select(x => new Team
                {
                    TeamKey = x.TeamKey,
                    ArenaKey = x.ArenaKey,
                    CoachName = x.CoachName,
                    Conference = x.Conference,
                    CurrentNBATeamFlag = x.CurrentNBATeamFlag,
                    LeagueKey = x.LeagueKey,
                    SubConference = x.SubConference,
                    TeamCity = x.TeamCity,
                    TeamCountry = x.TeamCountry,
                    TeamName = x.TeamName,
                    TeamNickname = x.TeamNickname,
                    URLPhoto = x.URLPhoto,
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackTrace($"Error occurred while getting the active teams: {ex.Message}");
                teams = null!;
            }

            return teams;
        }
    }
}
