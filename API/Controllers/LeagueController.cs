// <copyright file="LeagueController.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Controllers
{
    using API.Common.DTO;
    using API.Common.Models.Response;
    using API.Services.Interfaces;
    using Microsoft.ApplicationInsights;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This class represents all of the operations to be done on the <see cref="League"/> model.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LeagueController : ControllerBase
    {
        private readonly TelemetryClient telemetryClient;
        private readonly ILeagueService leagueService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueController"/> class.
        /// </summary>
        /// <param name="telemetryClient">The application insights injection.</param>
        /// <param name="leagueService">The league service injection.</param>
        public LeagueController(TelemetryClient telemetryClient, ILeagueService leagueService)
        {
            this.telemetryClient = telemetryClient;
            this.leagueService = leagueService;
        }

        /// <summary>
        /// Gets all of the leagues from the database.
        /// </summary>
        /// <returns>A unit of execution.</returns>
        [HttpGet("GetAllLeagues")]
        public async Task<ActionResult> GetAllLeaguesAsync()
        {
            GetAllLeaguesResponse apiResponse;

            try
            {
                var leagues = await this.leagueService.GetAllLeaguesAsync();

                apiResponse = new GetAllLeaguesResponse
                {
                    Leagues = leagues,
                    Count = leagues.Count,
                    Success = true,
                    ValidationErrors = null!,
                };
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackException(ex);

                apiResponse = new GetAllLeaguesResponse
                {
                    Leagues = null!,
                    Count = 0,
                    Success = false,
                    ValidationErrors = null!,
                };
            }

            return this.Ok(apiResponse);
        }
    }
}
