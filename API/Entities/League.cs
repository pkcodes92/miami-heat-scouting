// <copyright file="League.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Entities
{
    /// <summary>
    /// This class represents the league.
    /// </summary>
    public partial class League
    {
        /// <summary>
        /// Gets or sets the primary key for the league entity.
        /// </summary>
        public int LeagueKey { get; set; }

        /// <summary>
        /// Gets or sets the name of the league.
        /// </summary>
        public string LeagueName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the country of the league.
        /// </summary>
        public string Country { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating whether there is an active source.
        /// </summary>
        public bool ActiveSource { get; set; }

        /// <summary>
        /// Gets or sets the league group key.
        /// </summary>
        public int LeagueGroupKey { get; set; }

        /// <summary>
        /// Gets or sets the league custom group key.
        /// </summary>
        public int? LeagueCustomGroupKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not this record should display.
        /// </summary>
        public bool SearchDisplayFlag { get; set; }
    }
}