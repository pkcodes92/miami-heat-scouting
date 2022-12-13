// <copyright file="UserService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services
{
    using API.Common.DTO;
    using API.Data.Repository.Interfaces;
    using API.Services.Interfaces;
    using Microsoft.ApplicationInsights;

    /// <summary>
    /// This class will implement the methods defined in <see cref="IUserService"/>.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly TelemetryClient telemetryClient;
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="telemetryClient">The application insights injection.</param>
        /// <param name="userRepository">The user repository injection.</param>
        public UserService(TelemetryClient telemetryClient, IUserRepository userRepository)
        {
            this.telemetryClient = telemetryClient;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// This method returns all of the users from the database.
        /// </summary>
        /// <returns>A list of the users.</returns>
        public async Task<List<User>> GetAllUsersAsync()
        {
            var dbUsers = await this.userRepository.GetAllUsersAsync();

            return dbUsers.Select(x => new User
            {
                Name = x.Name,
                Email = x.Email,
                IsScout = x.ActiveFlag,
                ScoutId = x.AzureAdUserId,
            }).ToList();
        }

        /// <summary>
        /// This method returns all the active users from the database.
        /// </summary>
        /// <returns>A list of the active users.</returns>
        public async Task<List<User>> GetAllActiveUsersAsync()
        {
            var dbUsers = await this.userRepository.GetAllActiveUsersAsync();

            return dbUsers.Select(x => new User
            {
                Email = x.Email,
                IsScout = x.ActiveFlag,
                Name = x.Name,
                ScoutId = x.AzureAdUserId,
            }).ToList();
        }

        /// <summary>
        /// This method returns a single user.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <returns>A single user contained within a single unit of execution.</returns>
        public async Task<User> GetUserAsync(string name)
        {
            var dbUser = await this.userRepository.GetUserByNameAsync(name);

            var userToReturn = new User
            {
                Name = name,
                Email = dbUser.Email,
                IsScout = dbUser.ActiveFlag,
                ScoutId = dbUser.AzureAdUserId,
            };

            return userToReturn;
        }
    }
}
