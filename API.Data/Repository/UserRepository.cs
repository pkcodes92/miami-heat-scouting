// <copyright file="UserRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository
{
    using API.Data.Entities;
    using API.Data.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class implements the methods defined in <see cref="IUserRepository"/>.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ScoutContext scoutContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="scoutContext">The database context injection.</param>
        public UserRepository(ScoutContext scoutContext)
        {
            this.scoutContext = scoutContext;
        }

        /// <summary>
        /// Retrieves the user by the name from the database.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <returns>A single user which is having the data being entered.</returns>
        public async Task<User> GetUserByNameAsync(string name)
        {
            var result = await this.scoutContext.Users.FirstOrDefaultAsync(x => x.Name == name && x.ActiveFlag == true);
            return result!;
        }

        /// <summary>
        /// Retrieves all the users from the database.
        /// </summary>
        /// <returns>A list of users that are contained in the database.</returns>
        public async Task<List<User>> GetAllUsersAsync()
        {
            var result = await this.scoutContext.Users.ToListAsync();
            return result;
        }
    }
}
