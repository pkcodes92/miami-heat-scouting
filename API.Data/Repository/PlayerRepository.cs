// <copyright file="PlayerRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository
{
    using API.Data.Entities;
    using API.Data.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class implements the methods defined in <see cref="IPlayerRepository"/>.
    /// </summary>
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

        /// <summary>
        /// This method implementation retrieves a player by their name.
        /// </summary>
        /// <param name="firstName">The first name of the player.</param>
        /// <param name="lastName">The last name of the player.</param>
        /// <returns>A unit of execution which contains the <see cref="Player"/>.</returns>
        public async Task<Player> GetPlayerByFirstAndLastNameAsync(string firstName, string lastName)
        {
            var result = await this.scoutCountext.Players.FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName);
            return result!;
        }
    }
}
