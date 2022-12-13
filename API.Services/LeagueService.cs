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

        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueService"/> class.
        /// </summary>
        /// <param name="leagueRepository">The league repository injection.</param>
        public LeagueService(ILeagueRepository leagueRepository)
        {
            this.leagueRepository = leagueRepository;
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
    }
}
