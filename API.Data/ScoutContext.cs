// <copyright file="ScoutContext.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data
{
    using API.Data.Entities;
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
        /// Gets or sets the scout entities.
        /// </summary>
        public virtual DbSet<User> Users { get; set; } = null!;

        /// <summary>
        /// Gets or sets the scouting report entities.
        /// </summary>
        public virtual DbSet<ScoutingReport> ScoutingReports { get; set; } = null!;

        /// <summary>
        /// This method will be able to bind the database schema accordingly.
        /// </summary>
        /// <param name="modelBuilder">The model builder class.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<League>(entity =>
            {
                entity.HasKey(e => e.LeagueKey);
                entity.Property(e => e.LeagueKey).ValueGeneratedNever();
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.LeagueName).HasMaxLength(100);
                entity.Property(e => e.SearchDisplayFlag).IsRequired().HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamKey);
                entity.HasIndex(e => new { e.TeamKey, e.LeagueKey }, "UK_DimTeam").IsUnique();

                entity.Property(e => e.TeamKey).ValueGeneratedNever();
                entity.Property(e => e.CoachName).HasMaxLength(100);
                entity.Property(e => e.Conference).HasMaxLength(100);
                entity.Property(e => e.CurrentNBATeamFlag).HasColumnName("CurrentNBATeamFlg").HasDefaultValue("((0))");
                entity.Property(e => e.LeagueKeyDomestic).HasColumnName("LeagueKey_Domestic");
                entity.Property(e => e.SubConference).HasMaxLength(100);
                entity.Property(e => e.TeamCity).HasMaxLength(100);
                entity.Property(e => e.TeamCountry).HasMaxLength(100);
                entity.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.TeamNickname).HasMaxLength(100);
                entity.Property(e => e.UrlPhoto).HasMaxLength(250).HasColumnName("URLPhoto");

                entity.HasOne(d => d.LeagueKeyNavigation)
                      .WithMany(p => p.TeamLeagueKeyNavigation)
                      .HasForeignKey(d => d.LeagueKey)
                      .HasConstraintName("FK_Team_League");

                entity.HasOne(d => d.LeagueKeyDomesticNavigation)
                      .WithMany(p => p.TeamLeagueKeyDomesticNavigation)
                      .HasForeignKey(d => d.LeagueKeyDomestic)
                      .HasConstraintName("FK_Team_LeagueDomestic");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerKey);

                entity.Property(e => e.PlayerKey).ValueGeneratedNever();
                entity.Property(e => e.AgentName).HasMaxLength(200);
                entity.Property(e => e.AgentPhone).HasMaxLength(50);
                entity.Property(e => e.BirthDate).HasColumnType("date");
                entity.Property(e => e.BodyFat).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.BodyFatSource).HasMaxLength(100).HasColumnName("BodyFat_Source");
                entity.Property(e => e.CommittedTo).HasMaxLength(200);
                entity.Property(e => e.CourtRunTime).HasColumnType("decimal(5, 2)").HasColumnName("CourtRunTime_3_4");
            });

            modelBuilder.Entity<TeamPlayer>(entity =>
            {
                entity.HasKey(e => new { e.PlayerKey, e.TeamKey, e.SeasonKey });
                entity.Property(e => e.InsertDateTime).HasColumnType("datetime").HasColumnName("dwh_insert_datetime").HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PlayerKeyNavigation)
                      .WithMany(p => p.TeamPlayers)
                      .HasForeignKey(d => d.PlayerKey)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_TeamPlayer_Player");

                entity.HasOne(d => d.TeamKeyNavigation)
                      .WithMany(p => p.TeamPlayers)
                      .HasForeignKey(d => d.TeamKey)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_TeamPlayer_Team");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "dbo");

                entity.HasKey(e => e.AzureAdUserId).HasName("PK__User__76BABBB6FDC4FAD9");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.ActiveFlag).HasColumnType("bit");
                entity.Property(e => e.Order).HasColumnType("int").IsRequired(false);
            });

            modelBuilder.Entity<ScoutingReport>(entity =>
            {
                entity.ToTable("ScoutingReport", "dbo");

                entity.HasKey(e => e.ScoutingReportKey).HasName("PK_ScoutingReport");
                entity.Property(e => e.ScoutId).IsRequired().HasColumnType("nvarchar").HasMaxLength(450);
                entity.Property(e => e.PlayerKey).HasColumnType("int");
                entity.Property(e => e.TeamKey).HasColumnType("int");
                entity.Property(e => e.Defense).HasColumnType("int").HasColumnName("DefenseRating");
                entity.Property(e => e.Rebound).HasColumnType("int").HasColumnName("ReboundRating");
                entity.Property(e => e.Shooting).HasColumnType("int").HasColumnName("ShootingRating");
                entity.Property(e => e.Assist).HasColumnType("int").HasColumnName("AssistRating");
                entity.Property(e => e.Comments).HasColumnType("varchar");
                entity.Property(e => e.Created).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsCurrent).HasColumnType("bit").HasDefaultValueSql("((1))");
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