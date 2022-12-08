// <copyright file="ITeamRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository.Interfaces
{
    using API.Data.Entities;

    /// <summary>
    /// This interface defines the methods to be performed with the <see cref="Team"/> entity.
    /// </summary>
    public interface ITeamRepository
    {
        Task<int> InsertTeamAsync(Team team);

        Task<Team> GetTeamByKeyAsync(int teamKey);

        Task<Team> GetTeamByNameAndCityAsync(string teamName, string teamCity);

        Task<List<Team>> GetAllTeamsAsync();

        Task<List<Team>> GetAllActiveTeamsAsync();
    }
}
