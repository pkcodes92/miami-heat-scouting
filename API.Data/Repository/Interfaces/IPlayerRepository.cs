// <copyright file="IPlayerRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository.Interfaces
{
    using API.Data.Entities;

    /// <summary>
    /// This interface defines the CRUD operations to perform on the <see cref="Player"/> entity.
    /// </summary>
    public interface IPlayerRepository
    {
        /// <summary>
        /// This method definition will get a player by their first and last name.
        /// </summary>
        /// <param name="firstName">The player's first name.</param>
        /// <param name="lastName">The player's last name.</param>
        /// <returns>A unit of execution containing the player being returned.</returns>
        Task<Player> GetPlayerByFirstAndLastNameAsync(string firstName, string lastName);

        /// <summary>
        /// This method definition will get all the players from the database.
        /// </summary>
        /// <returns>A list of the type <see cref="Player"/>.</returns>
        Task<List<Player>> GetAllPlayersAsync();
    }
}
