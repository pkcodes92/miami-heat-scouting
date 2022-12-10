// <copyright file="User.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Common.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the user entity to be returned to the caller.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets a value indicating whether or not the user is a scout based on the active flag.
        /// </summary>
        [JsonProperty("isScout")]
        public bool IsScout { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = null!;
    }
}
