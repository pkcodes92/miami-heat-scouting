﻿// <copyright file="ITeamsService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services.Interfaces
{
    using API.Common.DTO;

    /// <summary>
    /// This interface defines the methods to be interacting with the <see cref="Team"/> entity.
    /// </summary>
    public interface ITeamsService
    {
        /// <summary>
        /// Retrieves all the active teams.
        /// </summary>
        /// <returns>A list of the active teams.</returns>
        Task<List<Team>> GetActiveTeamsAsync();

        /// <summary>
        /// Retrieves all teams.
        /// </summary>
        /// <returns>A list of all the teams in the database.</returns>
        Task<List<Team>> GetAllTeamsAsync();

        /// <summary>
        /// Retrieves a team by primary key.
        /// </summary>
        /// <param name="teamKey">The primary key of the team entity.</param>
        /// <returns>A single team entity.</returns>
        Task<Team> GetTeamByKeyAsync(int teamKey);
    }
}
