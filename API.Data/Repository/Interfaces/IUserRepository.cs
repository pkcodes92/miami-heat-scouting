// <copyright file="IUserRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository.Interfaces
{
    using API.Data.Entities;

    /// <summary>
    /// This interface defines all of the methods for the <see cref="User"/> entity.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// This method will allow for the user to be retrieved by their name.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <returns>A single user from the database.</returns>
        Task<User> GetUserByNameAsync(string name);
    }
}
