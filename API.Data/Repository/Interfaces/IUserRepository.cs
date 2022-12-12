// <copyright file="IUserRepository.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Repository.Interfaces
{
    using API.Data.Entities;

    /// <summary>
    /// This interface defines the CRUD operations to be performed on the <see cref="User"/> entity.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves a user by the name.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <returns>A single user from the database.</returns>
        Task<User> GetUserByNameAsync(string name);

        /// <summary>
        /// Retrieves all of the users from the database.
        /// </summary>
        /// <returns>A list of the users.</returns>
        Task<List<User>> GetAllUsersAsync();
    }
}
