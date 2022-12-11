// <copyright file="IScoutingReportRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository.Interfaces
{
    using API.Data.Entities;

    /// <summary>
    /// This interface defines the CRUD operations to be performed on the <see cref="ScoutingReport"/> entity.
    /// </summary>
    public interface IScoutingReportRepository
    {
        /// <summary>
        /// Inserts a new scouting report into the database.
        /// </summary>
        /// <param name="scoutingReport">The incoming scouting report entity.</param>
        /// <returns>The primary key of the scouting report.</returns>
        Task<int> InsertScoutingReportAsync(ScoutingReport scoutingReport);

        /// <summary>
        /// Retrieves a single scouting report by the primary key.
        /// </summary>
        /// <param name="scoutingReportKey">The primary key of the scouting report table.</param>
        /// <returns>A single entity which is of type <see cref="ScoutingReport"/>.</returns>
        Task<ScoutingReport> GetScoutingReportByKeyAsync(int scoutingReportKey);

        /// <summary>
        /// Retrieves all of the scouting reports that belong to a team.
        /// </summary>
        /// <param name="teamKey">The primary key of the <see cref="Team"/> entity.</param>
        /// <returns>A list of type <see cref="ScoutingReport"/>.</returns>
        Task<List<ScoutingReport>> GetScoutingReportsByTeamAsync(int teamKey);

        /// <summary>
        /// Retrieves all of the scouting reports from the database.
        /// </summary>
        /// <returns>A list of the type <see cref="ScoutingReport"/>.</returns>
        Task<List<ScoutingReport>> GetAllScoutingReportsAsync();

        /// <summary>
        /// Retrieves the scouting reports by the scout that created them.
        /// </summary>
        /// <param name="scoutId">The scout which created the scouting report.</param>
        /// <returns>A list of scouting reports.</returns>
        Task<List<ScoutingReport>> GetScoutingReportsByScoutAsync(string scoutId);
    }
}
