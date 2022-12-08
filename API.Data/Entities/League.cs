// <copyright file="League.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Entities
{
    /// <summary>
    /// This class represents the league.
    /// </summary>
    public partial class League
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="League"/> class.
        /// </summary>
        public League()
        {
            this.TeamLeagueKeyDomesticNavigation = new HashSet<Team>();
            this.TeamLeagueKeyNavigation = new HashSet<Team>();
        }

        /// <summary>
        /// Gets or sets the league key - the primary key.
        /// </summary>
        public int LeagueKey { get; set; }

        /// <summary>
        /// Gets or sets the name of the league.
        /// </summary>
        public string LeagueName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the country for the league.
        /// </summary>
        public string Country { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating whether the data is coming from an active source.
        /// </summary>
        public bool? ActiveSource { get; set; }

        /// <summary>
        /// Gets or sets the league group key.
        /// </summary>
        public int? LeagueGroupKey { get; set; }

        /// <summary>
        /// Gets or sets the league custom group key.
        /// </summary>
        public int? LeagueCustomGroupKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the league can appear in search.
        /// </summary>
        public bool? SearchDisplayFlag { get; set; }

        /// <summary>
        /// Gets or sets relevant team entities based on a domestic key.
        /// </summary>
        public virtual ICollection<Team> TeamLeagueKeyDomesticNavigation { get; set; } = null!;

        /// <summary>
        /// Gets or sets relevant team entities based on the league key.
        /// </summary>
        public virtual ICollection<Team> TeamLeagueKeyNavigation { get; set; } = null!;
    }
}