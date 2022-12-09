// <copyright file="TeamPlayer.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Common.DTO
{
    /// <summary>
    /// This class represents the TeamPlayer entity to return to the caller.
    /// </summary>
    public class TeamPlayer
    {
        /// <summary>
        /// Gets or sets the player key.
        /// </summary>
        public int PlayerKey { get; set; }

        /// <summary>
        /// Gets or sets the team key.
        /// </summary>
        public int TeamKey { get; set; }

        /// <summary>
        /// Gets or sets the season.
        /// </summary>
        public int Season { get; set; }
    }
}
