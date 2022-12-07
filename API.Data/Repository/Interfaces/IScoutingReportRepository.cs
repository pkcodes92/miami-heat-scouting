// <copyright file="IScoutingReportRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

using API.Data.Entities;

namespace API.Data.Repository.Interfaces
{
    public interface IScoutingReportRepository
    {
        Task<int> InsertScoutingReportAsync(ScoutingReport scoutingReport);

        Task<ScoutingReport> GetScoutingReportByKeyAsync(int scoutingReportKey);

        Task<List<ScoutingReport>> GetScoutingReportsByTeamAsync(int teamKey);

        Task<List<ScoutingReport>> GetAllScoutingReportsAsync();
    }
}
