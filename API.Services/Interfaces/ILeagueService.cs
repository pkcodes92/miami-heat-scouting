// <copyright file="ILeagueService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services.Interfaces
{
    using API.Common.DTO;

    /// <summary>
    /// This interface defines methods for the <see cref="League"/> model.
    /// </summary>
    public interface ILeagueService
    {
        /// <summary>
        /// Gets all of the leagues from the database.
        /// </summary>
        /// <returns>A list of the leagues in the database.</returns>
        Task<List<League>> GetAllLeaguesAsync();
    }
}
