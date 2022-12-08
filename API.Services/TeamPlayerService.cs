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
        /// This method returns the team players by the season.
        /// </summary>
        /// <param name="season">The season to search.</param>
        /// <returns>A list of team player entities.</returns>
        public async Task<List<TeamPlayer>> GetTeamPlayersBySeason(int season)
        {
            var dbTeamPlayers = await this.teamPlayerRepository.GetTeamPlayersBySeasonAsync(season);
            return null!;
        }
    }
}
