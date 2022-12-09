// <copyright file="PlayerService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API.Common.DTO;
    using API.Data.Repository.Interfaces;
    using API.Services.Interfaces;

    /// <summary>
    /// This service implements all of the methods defined in <see cref="IPlayerService"/>.
    /// </summary>
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerService"/> class.
        /// </summary>
        /// <param name="playerRepository">The player repository database injection.</param>
        public PlayerService(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        /// <summary>
        /// This method implementation will get all of the players.
        /// </summary>
        /// <returns>A list of the players.</returns>
        public async Task<List<Player>> GetAllPlayersAsync()
        {
            var dbPlayers = await this.playerRepository.GetAllPlayersAsync();

            return dbPlayers.Select(p => new Player
            {
                BirthDate = (DateTime)p.BirthDate!,
                FirstName = p.FirstName,
                LastName = p.LastName,
                PlayerId = p.PlayerKey,
            }).ToList();
        }

        /// <summary>
        /// Gets a single player from the database based on the first and last name.
        /// </summary>
        /// <param name="firstName">The first name of the player.</param>
        /// <param name="lastName">The last name of the player.</param>
        /// <returns>A single entity of type <see cref="Player"/>.</returns>
        public async Task<Player> GetPlayerByFirstAndLastNameAsync(string firstName, string lastName)
        {
            Player playerToReturn;
            var dbPlayer = await this.playerRepository.GetPlayerByFirstAndLastNameAsync(firstName, lastName);
            playerToReturn = new Player
            {
                FirstName = dbPlayer.FirstName,
                LastName = dbPlayer.LastName,
                BirthDate = (DateTime)dbPlayer.BirthDate!,
                PlayerId = dbPlayer.PlayerKey,
            };

            return playerToReturn;
        }
    }
}
