// <copyright file="LeagueService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services
{
    using API.Common.DTO;
    using API.Data.Repository.Interfaces;
    using API.Services.Interfaces;

    /// <summary>
    /// This class implements the methods defined in <see cref="ILeagueService"/>.
    /// </summary>
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository leagueRepository;
        private readonly ITeamRepository teamRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueService"/> class.
        /// </summary>
        /// <param name="leagueRepository">The league repository injection.</param>
        /// <param name="teamRepository">The team repository injection.</param>
        public LeagueService(ILeagueRepository leagueRepository, ITeamRepository teamRepository)
        {
            this.leagueRepository = leagueRepository;
            this.teamRepository = teamRepository;
        }

        /// <summary>
        /// Retrieves all of the leagues from the database.
        /// </summary>
        /// <returns>A list of the leagues.</returns>
        public async Task<List<League>> GetAllLeaguesAsync()
        {
            var dbLeagues = await this.leagueRepository.GetAllLeaguesAsync();

            return dbLeagues.Select(x => new League
            {
                DisplayFlag = (bool)x.SearchDisplayFlag!,
                Name = x.LeagueName,
                Country = x.Country,
                LeagueId = x.LeagueKey,
            }).ToList();
        }

        /// <summary>
        /// Retrieves the list of the teams by the League ID.
        /// </summary>
        /// <param name="leagueId">The primary key of the League table.</param>
        /// <returns>A list of the teams that belong to a particular league.</returns>
        public async Task<List<Team>> GetTeamsByLeagueAsync(int leagueId)
        {
            var dbTeams = await this.teamRepository.GetTeamsByLeagueAsync(leagueId);

            return dbTeams.Select(x => new Team
            {
                CoachName = x.CoachName,
                Conference = x.Conference,
                Division = x.SubConference,
                TeamCity = x.TeamCity,
                TeamCountry = x.TeamCountry,
                TeamKey = x.TeamKey,
                TeamName = x.TeamName,
                TeamNickname = x.TeamNickname,
            }).ToList();
        }
    }
}
