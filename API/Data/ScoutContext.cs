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

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player", "dbo");

                entity.HasKey(e => e.PlayerKey).HasName("PK_Player").IsClustered(true);

                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.BirthDate).HasColumnType("datetime");
                entity.Property(e => e.PositionKey).HasColumnType("int");
                entity.Property(e => e.AgentKey).HasColumnType("int");
                entity.Property(e => e.FreeAgentYear).HasColumnType("int");
                entity.Property(e => e.Height).HasColumnType("decimal(6, 4)");
                entity.Property(e => e.Weight).HasColumnType("decimal(6, 2)");
                entity.Property(e => e.YearsOfService).HasColumnType("int");
                entity.Property(e => e.Wing).HasColumnType("decimal(6, 4)");
                entity.Property(e => e.BodyFat).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.StandingReach).HasColumnType("decimal(6, 4)");
                entity.Property(e => e.CourtRunTime).HasColumnType("decimal(5, 2)").HasColumnName("CourtRunTime_3_4");
                entity.Property(e => e.VerticalJumpNoStep).HasColumnType("decimal(6, 4)");
                entity.Property(e => e.VerticalJumpMax).HasColumnType("decimal(6, 4)");
                entity.Property(e => e.HandWidth).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.HandLength).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.URLPhoto).IsRequired().HasMaxLength(250);
                entity.Property(e => e.ActiveAnalysisFlag).HasColumnName("ActiveAnalysisFlg").HasDefaultValueSql("((0))");
                entity.Property(e => e.LeagueCustomGroupKey).HasColumnType("int");
                entity.Property(e => e.BboPlayerKey).HasColumnType("int");
                entity.Property(e => e.InsertDateTime).HasColumnType("datetime").HasColumnName("dwh_insert_datetime");
                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime").HasColumnName("dwh_update_datetime");
                entity.Property(e => e.AgentName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.AgentPhone).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CommittedTo).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Handedness).IsRequired().HasMaxLength(10);
                entity.Property(e => e.GLPlayerKey).HasColumnType("int");
                entity.Property(e => e.PlayerStatusKey).HasColumnType("int");
                entity.Property(e => e.HeightSource).IsRequired().HasColumnName("Height_Source").HasMaxLength(100);
                entity.Property(e => e.WeightSource).IsRequired().HasColumnName("Weight_Source").HasMaxLength(100);
                entity.Property(e => e.WingSource).IsRequired().HasColumnName("Wing_Source").HasMaxLength(100);
                entity.Property(e => e.BodyFatSource).IsRequired().HasColumnName("BodyFat_Source").HasMaxLength(100);
                entity.Property(e => e.StandingReachSource).IsRequired().HasColumnName("StandingReach_Source").HasMaxLength(100);
                entity.Property(e => e.CourtRunTimeSource).IsRequired().HasColumnName("CourtRunTime_3_4_Source").HasMaxLength(100);
                entity.Property(e => e.VerticalJumpNoStepSource).IsRequired().HasColumnName("VerticalJumpNoStepSource_Source").HasMaxLength(100);
                entity.Property(e => e.VerticalJumpMaxSource).IsRequired().HasColumnName("VerticalJumpMax_Source").HasMaxLength(100);
                entity.Property(e => e.HandWHSource).IsRequired().HasColumnName("Hand_W_H_Source").HasMaxLength(100);
                entity.Property(e => e.Hand).IsRequired().HasMaxLength(10);
                entity.Property(e => e.IsCustomData).HasDefaultValueSql("((0))");
                entity.Property(e => e.HandednessSource).IsRequired().HasColumnName("Handedness_Source").HasMaxLength(100);
            });

            modelBuilder.Entity<TeamPlayer>(entity =>
            {
                entity.ToTable("TeamPlayer", "dbo");

                entity.HasKey(e => e.PlayerKey).HasName("PK_TeamPlayer");
                entity.Property(e => e.ActiveTeamFlag).HasColumnType("bit").HasColumnName("ActiveTeamFlg");
                entity.Property(e => e.InsertDateTime).HasColumnType("datetime").HasColumnName("dwh_insert_datetime");
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