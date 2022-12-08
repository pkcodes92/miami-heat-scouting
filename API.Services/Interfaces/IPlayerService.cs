// <copyright file="IPlayerService.cs" company="Miami Heat">
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
        /// This method definition retrieves a player by first and last name.
        /// </summary>
        /// <param name="firstName">The first name of the player to find.</param>
        /// <param name="lastName">The last name of the player to find.</param>
        /// <returns>A result of type <see cref="Player"/>.</returns>
        Task<Player> GetPlayerByFirstAndLastNameAsync(string firstName, string lastName);
    }
}
