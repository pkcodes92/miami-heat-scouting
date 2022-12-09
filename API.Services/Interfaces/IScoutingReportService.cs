// <copyright file="IScoutingReportService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services.Interfaces
{
    using API.Common.DTO;
    using API.Common.Models.Input;

    /// <summary>
    /// This interface will contain the necessary methods to perform CRUD operations on the <see cref="ScoutingReport"/> entity.
    /// </summary>
    public interface IScoutingReportService
    {
        /// <summary>
        /// Inserts a new scouting report.
        /// </summary>
        /// <param name="newScoutingReport">A new scouting report.</param>
        /// <returns>A new scouting report being added.</returns>
        Task<int> InsertScoutingReportAsync(IncomingScoutingReport newScoutingReport);

        /// <summary>
        /// Retrieves all scouting reports.
        /// </summary>
        /// <returns>A list of all the scouting reports.</returns>
        Task<List<ScoutingReport>> GetAllScoutingReportsAsync();
    }
}
