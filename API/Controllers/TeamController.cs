// <copyright file="TeamController.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Controllers
{
    using API.Data.Entities;
    using API.Services.Interfaces;
    using Microsoft.ApplicationInsights;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This class represents all of the CRUD operations to be performed with the <see cref="Team"/> model.
    /// </summary>
    [ApiController]
    [Route("Team")]
    public class TeamController : ControllerBase
    {
        private readonly TelemetryClient telemetryClient;
        private readonly ITeamsService teamsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamController"/> class.
        /// </summary>
        /// <param name="telemetryClient">Microsoft Application Insights injection.</param>
        /// <param name="teamsService">The teams entity data service.</param>
        public TeamController(TelemetryClient telemetryClient, ITeamsService teamsService)
        {
            this.telemetryClient = telemetryClient;
            this.teamsService = teamsService;
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
                teams = await this.teamsService.GetActiveTeamsAsync();
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackException(ex);
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
                teams = await this.teamsService.GetAllTeamsAsync();
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackException(ex);
                teams = null!;
            }

            return teams;
        }
    }
}
