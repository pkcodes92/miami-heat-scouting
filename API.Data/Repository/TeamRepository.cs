// <copyright file="TeamRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository
{
    using API.Data.Entities;
    using API.Data.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This repository implements the methods in <see cref="ITeamRepository"/>.
    /// </summary>
    public class TeamRepository : ITeamRepository
    {
        private readonly ScoutContext scoutContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamRepository"/> class.
        /// </summary>
        /// <param name="scoutContext">The database context injection.</param>
        public TeamRepository(ScoutContext scoutContext)
        {
            this.scoutContext = scoutContext;
        }

        /// <summary>
        /// Retrieves the active teams from the database.
        /// </summary>
        /// <returns>A list of the team entity.</returns>
        public async Task<List<Team>> GetAllActiveTeamsAsync()
        {
            var results = await this.scoutContext.Teams.Where(x => x.CurrentNBATeamFlag == true).ToListAsync();
            return results;
        }

        /// <summary>
        /// Retrieves all of the teams from the database.
        /// </summary>
        /// <returns>A list of the team entity.</returns>
        public async Task<List<Team>> GetAllTeamsAsync()
        {
            var results = await this.scoutContext.Teams.ToListAsync();
            return results;
        }

        /// <summary>
        /// Retrieves the team by the primary key.
        /// </summary>
        /// <param name="teamKey">The primary key of the team entity.</param>
        /// <returns>A single team to return.</returns>
        public async Task<Team> GetTeamByKeyAsync(int teamKey)
        {
            var result = await this.scoutContext.Teams.FirstOrDefaultAsync(x => x.TeamKey == teamKey);
            return result!;
        }

        /// <summary>
        /// Retrieves a team by the name and city.
        /// </summary>
        /// <param name="teamName">The team name.</param>
        /// <param name="teamCity">The team city.</param>
        /// <returns>A single team entity.</returns>
        public async Task<Team> GetTeamByNameAndCityAsync(string teamName, string teamCity)
        {
            var result = await this.scoutContext.Teams.FirstOrDefaultAsync(x => x.TeamName == teamName && x.TeamCity == teamCity);
            return result!;
        }

        /// <summary>
        /// Inserts a new team into the database.
        /// </summary>
        /// <param name="team">The team entity being added to the database.</param>
        /// <returns>The primary key of the team entity.</returns>
        public async Task<int> InsertTeamAsync(Team team)
        {
            this.scoutContext.Teams.Add(team);
            await this.scoutContext.SaveChangesAsync();
            var result = team.TeamKey;
            return result!;
        }
    }
}
