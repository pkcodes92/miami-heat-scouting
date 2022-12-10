// <copyright file="IUserService.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Services.Interfaces
{
    using API.Common.DTO;

    /// <summary>
    /// This interface defines all of the methods for the User entity.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// This method definition gets all of the users from the database.
        /// </summary>
        /// <returns>A list of users.</returns>
        Task<List<User>> GetAllUsersAsync();
    }
}
