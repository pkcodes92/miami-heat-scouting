// <copyright file="ScoutingReportRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository
{
    using API.Data.Entities;
    using API.Data.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class implements methods defined in <see cref="IScoutingReportRepository"/>.
    /// </summary>
    public class ScoutingReportRepository : IScoutingReportRepository
    {
        private readonly ScoutContext scoutContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoutingReportRepository"/> class.
        /// </summary>
        /// <param name="scoutContext">The database being injected.</param>
        public ScoutingReportRepository(ScoutContext scoutContext)
        {
            this.scoutContext = scoutContext;
        }

        /// <summary>
        /// Retrieves the scouting report by the primary key.
        /// </summary>
        /// <param name="scoutingReportKey">The primary key.</param>
        /// <returns>A single scouting report entity.</returns>
        public async Task<ScoutingReport> GetScoutingReportByKeyAsync(int scoutingReportKey)
        {
            var result = await this.scoutContext.ScoutingReports.FirstOrDefaultAsync(x => x.ScoutingReportKey == scoutingReportKey);
            return result!;
        }

        /// <summary>
        /// Retrieves scouting reports for a team.
        /// </summary>
        /// <param name="teamKey">The team primary key.</param>
        /// <returns>A list of scouting reports.</returns>
        public async Task<List<ScoutingReport>> GetScoutingReportsByTeamAsync(int teamKey)
        {
            var results = await this.scoutContext.ScoutingReports.ToListAsync();
            return results!;
        }

        /// <summary>
        /// Inserts a new scouting report into the database.
        /// </summary>
        /// <param name="scoutingReport">A scouting report to add.</param>
        /// <returns>The primary key of the scouting report entity.</returns>
        public async Task<int> InsertScoutingReportAsync(ScoutingReport scoutingReport)
        {
            this.scoutContext.ScoutingReports.Add(scoutingReport);
            await this.scoutContext.SaveChangesAsync();
            var result = scoutingReport.ScoutingReportKey;
            return result!;
        }

        /// <summary>
        /// Retrieves all of the scouting reports from the database.
        /// </summary>
        /// <returns>A list of the scouting reports.</returns>
        public async Task<List<ScoutingReport>> GetAllScoutingReportsAsync()
        {
            var results = await this.scoutContext.ScoutingReports.ToListAsync();
            return results!;
        }

        /// <summary>
        /// Retrieves all of the scouting reports that a scout has created.
        /// </summary>
        /// <param name="scoutId">The ID of the scout.</param>
        /// <returns>A list of scouting reports.</returns>
        public async Task<List<ScoutingReport>> GetScoutingReportsByScoutAsync(string scoutId)
        {
            var results = await this.scoutContext.ScoutingReports.Where(x => x.ScoutId == scoutId).ToListAsync();
            return results!;
        }

        /// <summary>
        /// Retrieves the grouped scouting reports by the scout ID.
        /// </summary>
        /// <param name="scoutId">The scout ID to retrieve the necessary reports.</param>
        /// <returns>A grouping result of all the scouting reports.</returns>
        public async Task<IEnumerable<IGrouping<int, ScoutingReport>>> GetGroupedScoutingReportsAsync(string scoutId)
        {
            var results = await this.scoutContext.ScoutingReports.Where(x => x.ScoutId == scoutId).GroupBy(x => x.TeamKey).ToListAsync();
            return results!;
        }

        /// <summary>
        /// Retrieves the scouting reports by the player and team primary keys.
        /// </summary>
        /// <param name="teamKey">The team primary key.</param>
        /// <param name="playerKey">The player primary key.</param>
        /// <returns>A list of scouting reports.</returns>
        public async Task<List<ScoutingReport>> GetScoutingReportByPlayerAndTeamAsync(int teamKey, int playerKey)
        {
            var results = await this.scoutContext.ScoutingReports.Where(x => x.TeamKey == teamKey && x.PlayerKey == playerKey).ToListAsync();
            return results!;
        }
    }
}
