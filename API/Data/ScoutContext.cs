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
    public partial class ScoutContext : DbContext
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

        /// <summary>
        /// Gets or sets the player entities.
        /// </summary>
        public virtual DbSet<Player> Players { get; set; } = null!;

        /// <summary>
        /// This method will be able to bind the database schema accordingly.
        /// </summary>
        /// <param name="modelBuilder">The model builder class.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<League>(entity => 
            {
                entity.ToTable("League", "dbo");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        /// <summary>
        /// This method will be executed when the configurations are being made.
        /// </summary>
        /// <param name="optionsBuilder">The necessary DB Context options.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // do nothing??
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}