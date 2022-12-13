// <copyright file="GetAllUsersResponse.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

#nullable disable

namespace API.Common.Models.Response
{
    using API.Common.DTO;
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the response when retrieving all users from the database.
    /// </summary>
    public class GetAllUsersResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the list of the users to return to the caller.
        /// </summary>
        [JsonProperty("users")]
        public List<User> Users { get; set; }
    }
}
