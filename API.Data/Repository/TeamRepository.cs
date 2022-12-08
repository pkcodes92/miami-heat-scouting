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
        /// This method definition will get all of the active teams in the database.
        /// </summary>
        /// <returns>A list of the team entity.</returns>
        public async Task<List<Team>> GetAllActiveTeamsAsync()
        {
            var results = await this.scoutContext.Teams.Where(x => x.CurrentNBATeamFlag == true).Select(x => new Team
            {
                CurrentNBATeamFlag = x.CurrentNBATeamFlag,
                LeagueKey = x.LeagueKey,
                ArenaKey = x.ArenaKey,
                CoachName = x.CoachName,
                Conference = x.Conference,
                SubConference = x.SubConference,
                TeamCity = x.TeamCity,
                TeamCountry = x.TeamCountry,
                TeamName = x.TeamName,
                TeamKey = x.TeamKey,
                TeamNickname = x.TeamNickname,
                UrlPhoto = x.UrlPhoto,
            }).ToListAsync();

            return results;
        }

        /// <summary>
        /// This method definition will get all of the teams from the database.
        /// </summary>
        /// <returns>A list of the team entity.</returns>
        public async Task<List<Team>> GetAllTeamsAsync()
        {
            var results = await this.scoutContext.Teams.Select(x => new Team
            {
                CurrentNBATeamFlag = x.CurrentNBATeamFlag,
                LeagueKey = x.LeagueKey,
                ArenaKey = x.ArenaKey,
                CoachName = x.CoachName,
                Conference = x.Conference,
                SubConference = x.SubConference,
                TeamCity = x.TeamCity,
                TeamCountry = x.TeamCountry,
                TeamName = x.TeamName,
                TeamKey = x.TeamKey,
                TeamNickname = x.TeamNickname,
                UrlPhoto = x.UrlPhoto,
            }).ToListAsync();

            return results!;
        }

        /// <summary>
        /// This method will get the team by the team key.
        /// </summary>
        /// <param name="teamKey">The primary key of the team entity.</param>
        /// <returns>A single team to return.</returns>
        public async Task<Team> GetTeamByKeyAsync(int teamKey)
        {
            var result = await this.scoutContext.Teams.FirstOrDefaultAsync(x => x.TeamKey == teamKey);
            return result!;
        }

        /// <summary>
        /// This method will return a team by the name and city.
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
        /// This method definition will return the necessary primary key of the team.
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
