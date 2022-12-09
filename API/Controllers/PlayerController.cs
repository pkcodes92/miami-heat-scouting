// <copyright file="PlayerController.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Controllers
{
    using API.Common.Models.Response;
    using API.Data.Entities;
    using API.Services.Interfaces;
    using Microsoft.ApplicationInsights;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This controller will have all the API methods for the <see cref="Player"/> entity.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly TelemetryClient telemetryClient;
        private readonly IPlayerService playerService;
        private readonly ITeamPlayerService teamPlayerService;
        private readonly ITeamsService teamsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerController"/> class.
        /// </summary>
        /// <param name="telemetryClient">The application insights injection.</param>
        /// <param name="playerService">The player service injection.</param>
        /// <param name="teamPlayerService">The team-player service injection.</param>
        /// <param name="teamsService">The teams service injection.</param>
        public PlayerController(
            TelemetryClient telemetryClient,
            IPlayerService playerService,
            ITeamPlayerService teamPlayerService,
            ITeamsService teamsService)
        {
            this.telemetryClient = telemetryClient;
            this.playerService = playerService;
            this.teamPlayerService = teamPlayerService;
            this.teamsService = teamsService;
        }

        /// <summary>
        /// This method will allow for an active player to be searched given a season.
        /// </summary>
        /// <param name="season">The NBA season to search in.</param>
        /// <param name="firstName">The first name of the player.</param>
        /// <param name="lastName">The last name of the player.</param>
        /// <returns>A unit of execution.</returns>
        [HttpGet("SearchPlayer/{season}")]
        public async Task<ActionResult> SearchPlayerAsync(int season, string firstName, string lastName)
        {
            SearchPlayerResponse apiResponse;
            this.telemetryClient.TrackTrace($"Searching for the player: {firstName} {lastName} in the {season} NBA season");

            var player = await this.playerService.GetPlayerByFirstAndLastNameAsync(firstName, lastName);

            var teamPlayer = await this.teamPlayerService.GetTeamPlayerBySeasonAsync(player.PlayerId, season);

            var teamInformation = await this.teamsService.GetTeamByKeyAsync(teamPlayer.TeamKey);

            if (player is null && teamPlayer is null && teamInformation is null)
            {
                apiResponse = new SearchPlayerResponse
                {
                    PlayerName = string.Empty,
                    TeamName = string.Empty,
                    Success = false,
                    Count = 0,
                    ValidationErrors = null!,
                };

                return this.NotFound(apiResponse);
            }
            else
            {
                apiResponse = new SearchPlayerResponse
                {
                    PlayerName = player!.GetFullName(),
                    TeamName = teamInformation!.GetFullTeamName(),
                    Season = teamPlayer!.Season,
                    Success = true,
                    Count = 1,
                    ValidationErrors = null!,
                };

                return this.Ok(apiResponse);
            }
        }

        /// <summary>
        /// This method will get all the players from the database.
        /// </summary>
        /// <returns>A unit of execution.</returns>
        [HttpGet("GetAllPlayers")]
        public async Task<ActionResult> GetAllPlayersAsync()
        {
            GetAllPlayersResponse apiResponse;

            try
            {
                var players = await this.playerService.GetAllPlayersAsync();

                apiResponse = new GetAllPlayersResponse
                {
                    Players = players,
                    Count = players.Count,
                    Success = true,
                    ValidationErrors = null!,
                };
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackException(ex);

                apiResponse = new GetAllPlayersResponse
                {
                    Success = false,
                    Count = 0,
                    ValidationErrors = null!,
                    Players = null!,
                };
            }

            return this.Ok(apiResponse);
        }
    }
}
