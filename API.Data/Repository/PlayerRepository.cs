// <copyright file="PlayerRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository
{
    using API.Data.Entities;
    using API.Data.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly ScoutContext scoutCountext;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerRepository"/> class.
        /// </summary>
        /// <param name="scoutCountext">The database injection.</param>
        public PlayerRepository(ScoutContext scoutCountext)
        {
            this.scoutCountext = scoutCountext;
        }

        public async Task<Player> GetPlayerByFirstAndLastNameAsync(string firstName, string lastName)
        {
            var result = await this.scoutCountext.Players.FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName);
            return result!;
        }
    }
}
