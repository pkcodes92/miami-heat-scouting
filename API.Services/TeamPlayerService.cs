// <copyright file="TeamPlayerService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services
{
    using API.Data.Entities;
    using API.Services.Interfaces;

    /// <summary>
    /// This is the service for the TeamPlayer entity.
    /// </summary>
    public class TeamPlayerService : ITeamPlayerService
    {
        /// <summary>
        /// Return a single team player querying by the key.
        /// </summary>
        /// <param name="teamPlayerKey">The primary key.</param>
        /// <returns>A single team player entity.</returns>
        public async Task<TeamPlayer> GetTeamPlayerByKey(int teamPlayerKey)
        {
            return null!;
        }

        /// <summary>
        /// This method returns the team players by the season.
        /// </summary>
        /// <param name="season">The season to search.</param>
        /// <returns>A list of team player entities.</returns>
        public async Task<List<TeamPlayer>> GetTeamPlayersBySeason(int season)
        {
            return null!;
        }
    }
}
