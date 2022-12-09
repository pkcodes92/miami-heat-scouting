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
    /// This class implements the methods defined in <see cref="ITeamPlayerRepository"/>.
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
        /// Retrieves an active player given a season.
        /// </summary>
        /// <param name="playerKey">The primary key of the player entity.</param>
        /// <param name="season">The season to search.</param>
        /// <returns>A single <see cref="TeamPlayer"/> entity which is also active.</returns>
        public async Task<TeamPlayer> GetActiveTeamPlayerAsync(int playerKey, int season)
        {
            var result = await this.scoutContext.TeamPlayers.FirstOrDefaultAsync(x => x.PlayerKey == playerKey &&
                x.SeasonKey == season && x.ActiveTeamFlag == true);
            return result!;
        }

        /// <summary>
        /// Retrieves all of the team players in a given season.
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
