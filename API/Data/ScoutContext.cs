// <copyright file="ScoutContext.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data
{
    using API.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class represents the database context, connecting to the database.
    /// </summary>
    public class ScoutContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScoutContext"/> class.
        /// </summary>
        public ScoutContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoutContext"/> class.
        /// </summary>
        /// <param name="options">The DB context options.</param>
        public ScoutContext(DbContextOptions<ScoutContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the league entities.
        /// </summary>
        public virtual DbSet<League> Leagues { get; set; } = null!;

        /// <summary>
        /// Gets or sets the team player entities.
        /// </summary>
        public virtual DbSet<TeamPlayer> TeamPlayers { get; set; } = null!;

        /// <summary>
        /// Gets or sets the team entities.
        /// </summary>
        public virtual DbSet<Team> Teams { get; set; } = null!;
    }
}