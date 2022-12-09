// <copyright file="ITeamPlayerRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository.Interfaces
{
    using API.Data.Entities;

    /// <summary>
    /// This interface defines all of the methods to be done for the <see cref="TeamPlayer"/> entity.
    /// </summary>
    public interface ITeamPlayerRepository
    {
        /// <summary>
        /// Retrieves all of the players in a season.
        /// </summary>
        /// <param name="season">The season to find the players.</param>
        /// <returns>A list of type <see cref="TeamPlayer"/>.</returns>
        public Task<List<TeamPlayer>> GetTeamPlayersBySeasonAsync(int season);

        /// <summary>
        /// Retrieves a single team player record by the player key and season.
        /// </summary>
        /// <param name="playerKey">The primary key of the player entity.</param>
        /// <param name="season">The season to search.</param>
        /// <returns>A single result of type <see cref="TeamPlayer"/>.</returns>
        public Task<TeamPlayer> GetActiveTeamPlayerAsync(int playerKey, int season);
    }
}
