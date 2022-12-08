// <copyright file="Team.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Entities
{
    /// <summary>
    /// This class represents the team entity.
    /// </summary>
    public partial class Team
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class.
        /// </summary>
        public Team()
        {
            this.TeamPlayers = new HashSet<TeamPlayer>();
        }

        /// <summary>
        /// Gets or sets the team key - the primary key.
        /// </summary>
        public int TeamKey { get; set; }

        /// <summary>
        /// Gets or sets the league key.
        /// </summary>
        public int? LeagueKey { get; set; }

        /// <summary>
        /// Gets or sets a domestic league value.
        /// </summary>
        public int? LeagueKeyDomestic { get; set; }

        /// <summary>
        /// Gets or sets the arena key.
        /// </summary>
        public int? ArenaKey { get; set; }

        /// <summary>
        /// Gets or sets the team name.
        /// </summary>
        public string TeamName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the team nickname.
        /// </summary>
        public string TeamNickname { get; set; } = null!;

        /// <summary>
        /// Gets or sets the conference.
        /// </summary>
        public string Conference { get; set; } = null!;

        /// <summary>
        /// Gets or sets the sub-conference, or the division.
        /// </summary>
        public string SubConference { get; set; } = null!;

        /// <summary>
        /// Gets or sets the team city.
        /// </summary>
        public string TeamCity { get; set; } = null!;

        /// <summary>
        /// Gets or sets the team country.
        /// </summary>
        public string TeamCountry { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the head coach.
        /// </summary>
        public string CoachName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the photo URL.
        /// </summary>
        public string UrlPhoto { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating whether the team is currently in the NBA.
        /// </summary>
        public bool? CurrentNBATeamFlag { get; set; }

        /// <summary>
        /// Gets or sets the relevant league entity based on a domestic key.
        /// </summary>
        public virtual League LeagueKeyDomesticNavigation { get; set; } = null!;

        /// <summary>
        /// Gets or sets the relevant league entity.
        /// </summary>
        public virtual League LeagueKeyNavigation { get; set; } = null!;

        /// <summary>
        /// Gets or sets the relevant TeamPlayer entities.
        /// </summary>
        public virtual ICollection<TeamPlayer> TeamPlayers { get; set; }
    }
}