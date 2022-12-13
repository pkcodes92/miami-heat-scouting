// <copyright file="ITeamRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository.Interfaces
{
    using API.Data.Entities;

    /// <summary>
    /// This interface defines the CRUD operations to be performed on the <see cref="Team"/> entity.
    /// </summary>
    public interface ITeamRepository
    {
        /// <summary>
        /// Inserts a new team into the database.
        /// </summary>
        /// <param name="team">A new team that is to be inserted.</param>
        /// <returns>The primary key of the team being inserted.</returns>
        Task<int> InsertTeamAsync(Team team);

        /// <summary>
        /// Retrieves a team by the primary key.
        /// </summary>
        /// <param name="teamKey">The primary key of the team entity.</param>
        /// <returns>A type of <see cref="Team"/>.</returns>
        Task<Team> GetTeamByKeyAsync(int teamKey);

        /// <summary>
        /// Retrieves a team given the name and the city.
        /// </summary>
        /// <param name="teamName">The name of the team.</param>
        /// <param name="teamCity">The city where the team plays.</param>
        /// <returns>A type of <see cref="Team"/>.</returns>
        Task<Team> GetTeamByNameAndCityAsync(string teamName, string teamCity);

        /// <summary>
        /// Retrieves all of the teams in the database.
        /// </summary>
        /// <returns>A list of type <see cref="Team"/>.</returns>
        Task<List<Team>> GetAllTeamsAsync();

        /// <summary>
        /// Retrieves all of the active teams in the database.
        /// </summary>
        /// <returns>A list of type <see cref="Team"/>.</returns>
        Task<List<Team>> GetAllActiveTeamsAsync();

        /// <summary>
        /// Retrieves all the teams which are part of a league.
        /// </summary>
        /// <param name="leagueId">The primary key of the league entity.</param>
        /// <returns>A list of teams that belong to a league.</returns>
        Task<List<Team>> GetTeamsByLeagueAsync(int leagueId);
    }
}
