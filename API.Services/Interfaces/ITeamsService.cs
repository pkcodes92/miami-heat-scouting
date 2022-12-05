// <copyright file="ITeamsService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services.Interfaces
{
    /// <summary>
    /// This interface defines the methods to be interacting with the <see cref="Team"/> entity.
    /// </summary>
    public interface ITeamsService
    {
        /// <summary>
        /// This method definition returns all the active NBA teams.
        /// </summary>
        /// <returns>A list of the active teams.</returns>
        Task<List<Team>> GetActiveTeamsAsync();

        /// <summary>
        /// This method definition will get all of the teams in the database.
        /// </summary>
        /// <returns>A list of all the teams in the database.</returns>
        Task<List<Team>> GetAllTeamsAsync();
    }
}
