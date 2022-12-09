// <copyright file="TeamPlayerService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services
{
    using API.Common.DTO;
    using API.Data.Repository.Interfaces;
    using API.Services.Interfaces;

    /// <summary>
    /// This is the service for the TeamPlayer entity.
    /// </summary>
    public class TeamPlayerService : ITeamPlayerService
    {
        private readonly ITeamPlayerRepository teamPlayerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamPlayerService"/> class.
        /// </summary>
        /// <param name="teamPlayerRepository">The player team database layer injection.</param>
        public TeamPlayerService(ITeamPlayerRepository teamPlayerRepository)
        {
            this.teamPlayerRepository = teamPlayerRepository;
        }

        /// <summary>
        /// Retrieves the team players in a season.
        /// </summary>
        /// <param name="season">The season to search.</param>
        /// <returns>A list of team player entities.</returns>
        public async Task<List<TeamPlayer>> GetTeamPlayersBySeasonAsync(int season)
        {
            var dbTeamPlayers = await this.teamPlayerRepository.GetTeamPlayersBySeasonAsync(season);
            return dbTeamPlayers.Select(x => new TeamPlayer
            {
                PlayerKey = x.PlayerKey,
                Season = x.SeasonKey,
                TeamKey = x.TeamKey,
            }).ToList();
        }

        /// <summary>
        /// Retrieves a team player by the player key and season.
        /// </summary>
        /// <param name="playerKey">The player primary key.</param>
        /// <param name="season">The season to search.</param>
        /// <returns>A single <see cref="TeamPlayer"/> record.</returns>
        public async Task<TeamPlayer> GetTeamPlayerBySeasonAsync(int playerKey, int season)
        {
            TeamPlayer recordToReturn;

            var dbTeamPlayer = await this.teamPlayerRepository.GetActiveTeamPlayerAsync(playerKey, season);

            recordToReturn = new TeamPlayer
            {
                PlayerKey = (int)dbTeamPlayer?.PlayerKey!,
                Season = (int)dbTeamPlayer?.SeasonKey!,
                TeamKey = (int)dbTeamPlayer?.TeamKey!,
            };

            return recordToReturn;
        }
    }
}
