﻿// <copyright file="IPlayerService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services.Interfaces
{
    using API.Common.DTO;

    /// <summary>
    /// This interface defines all of the methods for the <see cref="Player"/> entity.
    /// </summary>
    public interface IPlayerService
    {
        /// <summary>
        /// Retrieves a player by first and last name.
        /// </summary>
        /// <param name="firstName">The first name of the player to find.</param>
        /// <param name="lastName">The last name of the player to find.</param>
        /// <returns>A result of type <see cref="Player"/>.</returns>
        Task<Player> GetPlayerByFirstAndLastNameAsync(string firstName, string lastName);

        /// <summary>
        /// Retrieves all the players.
        /// </summary>
        /// <returns>A list of type <see cref="Player"/>.</returns>
        Task<List<Player>> GetAllPlayersAsync();

        /// <summary>
        /// Retrieves a single player.
        /// </summary>
        /// <param name="playerKey">The primary key of the player.</param>
        /// <returns>A single result of the type <see cref="Player"/>.</returns>
        Task<Player> GetPlayerByKeyAsync(int playerKey);
    }
}
