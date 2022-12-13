// <copyright file="ILeagueRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository.Interfaces
{
    using API.Data.Entities;

    /// <summary>
    /// This repository definition contains methods to perform CRUD operations on the <see cref="League"/> entity.
    /// </summary>
    public interface ILeagueRepository
    {
        /// <summary>
        /// Retrieves all of the leagues from the database.
        /// </summary>
        /// <returns>A list of all of the leagues.</returns>
        Task<List<League>> GetAllLeaguesAsync();
    }
}
