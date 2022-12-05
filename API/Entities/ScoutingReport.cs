// <copyright file="ScoutingReport.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Entities
{
    /// <summary>
    /// This class represents the scouting report entity.
    /// </summary>
    public partial class ScoutingReport
    {
        /// <summary>
        /// Gets or sets the scouting report key - the primary key.
        /// </summary>
        public int ScoutingReportKey { get; set; }

        /// <summary>
        /// Gets or sets the scout key.
        /// </summary>
        public int ScoutKey { get; set; }

        /// <summary>
        /// Gets or sets the player key.
        /// </summary>
        public int PlayerKey { get; set; }

        /// <summary>
        /// Gets or sets the team key.
        /// </summary>
        public int TeamKey { get; set; }

        /// <summary>
        /// Gets or sets the defense rating.
        /// </summary>
        public int Defense { get; set; }

        /// <summary>
        /// Gets or sets the rebound rating.
        /// </summary>
        public int Rebound { get; set; }

        /// <summary>
        /// Gets or sets the shooting rating.
        /// </summary>
        public int Shooting { get; set; }

        /// <summary>
        /// Gets or sets the assist rating.
        /// </summary>
        public int Assist { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public string Comments { get; set; } = null!;

        /// <summary>
        /// Gets or sets the date/time the record is created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the scouting report is current.
        /// </summary>
        public bool IsCurrent { get; set; }
    }
}
