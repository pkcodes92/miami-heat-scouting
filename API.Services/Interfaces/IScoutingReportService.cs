// <copyright file="IScoutingReportService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services.Interfaces
{
    using API.Data.Entities;
    using API.Data.Models.Input;

    /// <summary>
    /// This interface will contain the necessary methods to perform CRUD operations on the <see cref="ScoutingReport"/> entity.
    /// </summary>
    public interface IScoutingReportService
    {
        /// <summary>
        /// This method definition will insert a new scouting report into the database.
        /// </summary>
        /// <param name="newScoutingReport">A new scouting report.</param>
        /// <returns>A new scouting report being added.</returns>
        Task<int> InsertScoutingReport(IncomingScoutingReport newScoutingReport);
    }
}
