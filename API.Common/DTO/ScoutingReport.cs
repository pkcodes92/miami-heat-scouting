// <copyright file="ScoutingReport.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Common.DTO
{
    /// <summary>
    /// This class will get the necessary scouting report.
    /// </summary>
    public class ScoutingReport
    {
        /// <summary>
        /// Gets or sets the scout ID.
        /// </summary>
        public string ScoutId { get; set; } = null!;

        /// <summary>
        /// Gets or sets the assist rating.
        /// </summary>
        public int Assist { get; set; }
        
        /// <summary>
        /// Gets or sets the defensive rating.
        /// </summary>
        public int Defense { get; set; }

        /// <summary>
        /// Gets or sets the shooting rating.
        /// </summary>
        public int Shooting { get; set; }

        /// <summary>
        /// Gets or sets the rebounding rating.
        /// </summary>
        public int Rebound { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public string Comments { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating if the scouting report is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
