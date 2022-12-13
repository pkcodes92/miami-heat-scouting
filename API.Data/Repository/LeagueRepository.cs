// <copyright file="LeagueRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository
{
    using API.Data.Entities;
    using API.Data.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class implements all of the necessary methods in <see cref="ILeagueRepository"/>.
    /// </summary>
    public class LeagueRepository : ILeagueRepository
    {
        private readonly ScoutContext scoutContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueRepository"/> class.
        /// </summary>
        /// <param name="scoutContext">The database injection.</param>
        public LeagueRepository(ScoutContext scoutContext)
        {
            this.scoutContext = scoutContext;
        }

        /// <summary>
        /// Retrieves all of the leagues from the database.
        /// </summary>
        /// <returns>A unit of execution which contains all of the leagues.</returns>
        public async Task<List<League>> GetAllLeaguesAsync()
        {
            var results = await this.scoutContext.Leagues.ToListAsync();
            return results!;
        }
    }
}
