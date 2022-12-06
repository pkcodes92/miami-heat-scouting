﻿// <copyright file="IScoutingReportService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services.Interfaces
{
    using API.Data.Entities;

    /// <summary>
    /// This interface will contain the necessary methods to perform CRUD operations on the <see cref="ScoutingReport"/> entity.
    /// </summary>
    public interface IScoutingReportService
    {
        /// <summary>
        /// This method definition will insert a new scouting report into the database.
        /// </summary>
        /// <returns>A new scouting report being added.</returns>
        Task<ScoutingReport> InsertScoutingReport();
    }
}
