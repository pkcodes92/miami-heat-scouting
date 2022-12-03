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

                entity.HasKey(e => e.LeagueKey).IsClustered(true).HasName("PK_League");
                entity.Property(e => e.LeagueName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.ActiveSource).HasDefaultValueSql("((1))");
                entity.Property(e => e.LeagueGroupKey).HasColumnType("int");
                entity.Property(e => e.LeagueCustomGroupKey).HasColumnType("int");
                entity.Property(e => e.SearchDisplayFlag).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team", "dbo");

                entity.HasKey(e => e.TeamKey).HasName("PK_Team").IsClustered(true);
                entity.HasKey(e => e.LeagueKeyDomestic).HasName("FK_Team_LeagueDomestic");

                entity.Property(e => e.ArenaKey).HasColumnType("int");
                entity.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.TeamNickname).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Conference).IsRequired().HasMaxLength(100);
                entity.Property(e => e.SubConference).IsRequired().HasMaxLength(100);
                entity.Property(e => e.TeamCity).IsRequired().HasMaxLength(100);
                entity.Property(e => e.TeamCountry).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CoachName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.URLPhoto).IsRequired().HasMaxLength(250);
                entity.Property(e => e.CurrentNBATeamFlag).HasDefaultValueSql("((0))");
                entity.Property(e => e.LeagueKeyDomestic).HasColumnType("int").HasColumnName("LeageKey_Domestic");
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