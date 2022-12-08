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
    }
}
