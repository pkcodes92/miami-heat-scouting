// <copyright file="Team.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Entities
{
    /// <summary>
    /// This class represents the team entity.
    /// </summary>
    public partial class Team
    {
        /// <summary>
        /// Gets or sets the primary key for the team.
        /// </summary>
        public int TeamKey { get; set; }

        /// <summary>
        /// Gets or sets the league key.
        /// </summary>
        public int? LeagueKey { get; set; }

        /// <summary>
        /// Gets or sets the league key for the domestic league.
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
        public string? TeamNickname { get; set; }

        /// <summary>
        /// Gets or sets the conference.
        /// </summary>
        public string? Conference { get; set; }

        /// <summary>
        /// Gets or sets the sub-conference for the team.
        /// </summary>
        public string? SubConference { get; set; }

        /// <summary>
        /// Gets or sets the city where the team plays in.
        /// </summary>
        public string? TeamCity { get; set; }

        /// <summary>
        /// Gets or sets the country of the team.
        /// </summary>
        public string? TeamCountry { get; set; }

        /// <summary>
        /// Gets or sets the name of the coach.
        /// </summary>
        public string? CoachName { get; set; }

        /// <summary>
        /// Gets or sets the URL of the photo.
        /// </summary>
        public string? URLPhoto { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the team is currently in the NBA.
        /// </summary>
        public bool? CurrentNBATeamFlag { get; set; }
    }
}