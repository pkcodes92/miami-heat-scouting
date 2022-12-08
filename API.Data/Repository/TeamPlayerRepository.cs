// <copyright file="TeamPlayerRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API.Data.Entities;
    using API.Data.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class will implement the methods defined in <see cref="ITeamPlayerRepository"/>.
    /// </summary>
    public class TeamPlayerRepository : ITeamPlayerRepository
    {
        private readonly ScoutContext scoutContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamPlayerRepository"/> class.
        /// </summary>
        /// <param name="scoutContext">The database context injection.</param>
        public TeamPlayerRepository(ScoutContext scoutContext)
        {
            this.scoutContext = scoutContext;
        }

        /// <summary>
        /// This method implementation gets all of the team players in a given season.
        /// </summary>
        /// <param name="season">The season to search for players.</param>
        /// <returns>A list of type <see cref="TeamPlayer"/>.</returns>
        public async Task<List<TeamPlayer>> GetTeamPlayersBySeasonAsync(int season)
        {
            var results = await this.scoutContext.TeamPlayers.Where(x => x.SeasonKey == season).ToListAsync();
            return results!;
        }
    }
}
