// <copyright file="ITeamPlayerService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services.Interfaces
{
    using API.Data.Entities;

    /// <summary>
    /// This interface defines the methods for the <see cref="TeamPlayer"/> entity.
    /// </summary>
    public interface ITeamPlayerService
    {
        /// <summary>
        /// Gets the team player record by the primary key.
        /// </summary>
        /// <param name="teamPlayerKey">The primary key.</param>
        /// <returns>The appropriate team player record.</returns>
        Task<TeamPlayer> GetTeamPlayerByKey(int teamPlayerKey);

        /// <summary>
        /// Gets the necessary records per season.
        /// </summary>
        /// <param name="season">The season value.</param>
        /// <returns>A list of the type of <see cref="TeamPlayer"/>.</returns>
        Task<List<TeamPlayer>> GetTeamPlayersBySeason(int season);
    }
}
