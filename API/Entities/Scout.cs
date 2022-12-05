// <copyright file="Scout.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Entities
{
    /// <summary>
    /// This class represents the Scout entity.
    /// </summary>
    public partial class Scout
    {
        /// <summary>
        /// Gets or sets the scout key - the primary key.
        /// </summary>
        public int ScoutKey { get; set; }

        /// <summary>
        /// Gets or sets the scout first name.
        /// </summary>
        public string ScoutFirstName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the scout last name.
        /// </summary>
        public string ScoutLastName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the date/time the record was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the scout is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
