// <copyright file="UserRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository
{
    using API.Data.Entities;
    using API.Data.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : IUserRepository
    {
        private readonly ScoutContext scoutContext;

        public UserRepository(ScoutContext scoutContext)
        {
            this.scoutContext = scoutContext;
        }

        /// <summary>
        /// This method will retrieve the user by the name from the database.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <returns>A single user which is having the data being entered.</returns>
        public async Task<User> GetUserByNameAsync(string name)
        {
            var result = await this.scoutContext.Users.FirstOrDefaultAsync(x => x.Name == name && x.ActiveFlag == true);
            return result!;
        }
    }
}
