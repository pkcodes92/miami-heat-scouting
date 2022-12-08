// <copyright file="TeamPlayer.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Entities
{
    /// <summary>
    /// This class represents the TeamPlayer table.
    /// </summary>
    public partial class TeamPlayer
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
        /// Gets or sets the season key.
        /// </summary>
        public int SeasonKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the combination of team and player are active.
        /// </summary>
        public bool? ActiveTeamFlag { get; set; }

        /// <summary>
        /// Gets or sets the date/time when the team player entity has been inserted.
        /// </summary>
        public DateTime InsertDateTime { get; set; }
    }
}