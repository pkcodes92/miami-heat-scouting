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

        /// <summary>
        /// Gets all of the teams filtered by the league.
        /// </summary>
        /// <param name="leagueKey">The league primary key.</param>
        /// <returns>A list of teams that belong to a league.</returns>
        Task<List<Team>> GetTeamsByLeagueAsync(int leagueKey);
    }
}
