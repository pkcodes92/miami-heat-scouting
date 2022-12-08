// <copyright file="ITeamPlayerService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services.Interfaces
{
    using API.Common.DTO;

    /// <summary>
    /// This interface defines the methods for the <see cref="TeamPlayer"/> entity.
    /// </summary>
    public interface ITeamPlayerService
    {
        /// <summary>
        /// Gets the necessary records per season.
        /// </summary>
        /// <param name="season">The season value.</param>
        /// <returns>A list of the type of <see cref="TeamPlayer"/>.</returns>
        Task<List<TeamPlayer>> GetTeamPlayersBySeason(int season);
    }
}
