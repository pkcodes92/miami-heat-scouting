// <copyright file="Team.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Common.DTO
{
    /// <summary>
    /// This class represents the Team model to return to the API caller.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Gets or sets the team nickname.
        /// </summary>
        public string TeamNickname { get; set; } = null!;

        /// <summary>
        /// Gets or sets the team name.
        /// </summary>
        public string TeamName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the conference.
        /// </summary>
        public string Conference { get; set; } = null!;

        /// <summary>
        /// Gets or sets the subconference.
        /// </summary>
        public string Division { get; set; } = null!;

        /// <summary>
        /// Gets or sets the coach name.
        /// </summary>
        public string CoachName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the team city.
        /// </summary>
        public string TeamCity { get; set; } = null!;

        /// <summary>
        /// Gets or sets the team country.
        /// </summary>
        public string TeamCountry { get; set; } = null!;

        /// <summary>
        /// Gets or sets the team key.
        /// </summary>
        public int TeamKey { get; set; }
    }
}
