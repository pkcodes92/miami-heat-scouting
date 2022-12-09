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
                entity.ToTable("League", "dbo");
                entity.HasKey(e => e.LeagueKey);

                entity.Property(e => e.LeagueKey).ValueGeneratedNever();
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.LeagueName).HasMaxLength(100);

                entity.Property(e => e.SearchDisplayFlag)
                      .IsRequired()
                      .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team", "dbo");
                entity.HasKey(e => e.TeamKey);
                entity.HasIndex(e => new { e.TeamKey, e.LeagueKey }, "UK_DimTeam").IsUnique();

                entity.Property(e => e.TeamKey).ValueGeneratedNever();
                entity.Property(e => e.CoachName).HasMaxLength(100);
                entity.Property(e => e.Conference).HasMaxLength(100);

                entity.Property(e => e.CurrentNBATeamFlag)
                      .HasColumnName("CurrentNBATeamFlg");

                entity.Property(e => e.LeagueKeyDomestic).HasColumnName("LeagueKey_Domestic");
                entity.Property(e => e.SubConference).HasMaxLength(100);
                entity.Property(e => e.TeamCity).HasMaxLength(100);
                entity.Property(e => e.TeamCountry).HasMaxLength(100);
                entity.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.TeamNickname).HasMaxLength(100);

                entity.Property(e => e.UrlPhoto)
                      .HasMaxLength(250)
                      .HasColumnName("URLPhoto");

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
                entity.ToTable("Player", "dbo");
                entity.HasKey(e => e.PlayerKey);

                entity.Property(e => e.PlayerKey).ValueGeneratedNever();
                entity.Property(e => e.ActiveAnalysisFlag).HasColumnName("ActiveAnalysisFlg");
                entity.Property(e => e.AgentName).HasMaxLength(200);
                entity.Property(e => e.AgentPhone).HasMaxLength(50);
                entity.Property(e => e.BirthDate).HasColumnType("date");
                entity.Property(e => e.BodyFat).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.BodyFatSource)
                      .HasMaxLength(100)
                      .HasColumnName("BodyFat_Source");

                entity.Property(e => e.CommittedTo).HasMaxLength(200);

                entity.Property(e => e.CourtRunTime)
                      .HasColumnType("decimal(5, 2)")
                      .HasColumnName("CourtRunTime_3_4");

                entity.Property(e => e.CourtRunTimeSource)
                      .HasMaxLength(100)
                      .HasColumnName("CourtRunTime_3_4_Source");

                entity.Property(e => e.InsertDateTime)
                      .HasColumnType("datetime")
                      .HasColumnName("dwh_insert_datetime")
                      .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateDateTime)
                      .HasColumnType("datetime")
                      .HasColumnName("dwh_update_datetime")
                      .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.GlPlayerKey).HasColumnName("GLPlayerKey");
                entity.Property(e => e.Hand).HasMaxLength(10);
                entity.Property(e => e.HandLength).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.HandWHSource)
                      .HasMaxLength(100)
                      .HasColumnName("Hand_W_H_Source");

                entity.Property(e => e.HandWidth).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.Handedness).HasMaxLength(10);

                entity.Property(e => e.HandednessSource)
                      .HasMaxLength(100)
                      .HasColumnName("Handedness_Source");

                entity.Property(e => e.Height).HasColumnType("decimal(6, 4)");

                entity.Property(e => e.HeightSource)
                      .HasMaxLength(100)
                      .HasColumnName("Height_Source");

                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.StandingReach).HasColumnType("decimal(6, 4)");

                entity.Property(e => e.StandingReachSource)
                      .HasMaxLength(100)
                      .HasColumnName("StandingReach_Source");

                entity.Property(e => e.UrlPhoto)
                      .HasMaxLength(250)
                      .HasColumnName("URLPhoto");

                entity.Property(e => e.VerticalJumpMax).HasColumnType("decimal(6, 4)");

                entity.Property(e => e.VerticalJumpMaxSource)
                      .HasMaxLength(100)
                      .HasColumnName("VerticalJumpMax_Source");

                entity.Property(e => e.VerticalJumpNoStep).HasColumnType("decimal(6, 4)");

                entity.Property(e => e.VerticalJumpNoStepSource)
                      .HasMaxLength(100)
                      .HasColumnName("VerticalJumpNoStep_Source");

                entity.Property(e => e.Weight).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.WeightSource)
                      .HasMaxLength(100)
                      .HasColumnName("Weight_Source");

                entity.Property(e => e.Wing).HasColumnType("decimal(6, 4)");

                entity.Property(e => e.WingSource)
                      .HasMaxLength(100)
                      .HasColumnName("Wing_Source");
            });

            modelBuilder.Entity<TeamPlayer>(entity =>
            {
                entity.ToTable("TeamPlayer", "dbo");
                entity.HasKey(e => new { e.PlayerKey, e.TeamKey, e.SeasonKey });

                entity.Property(e => e.ActiveTeamFlag).HasColumnName("ActiveTeamFlg");

                entity.Property(e => e.InsertDateTime)
                      .HasColumnType("datetime")
                      .HasColumnName("dwh_insert_datetime")
                      .HasDefaultValueSql("(getdate())");

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
                entity.HasKey(e => e.AzureAdUserId).HasName("PK__User__76BABBB6FEEB0689");

                entity.Property(e => e.ActiveFlag)
                      .IsRequired()
                      .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                      .IsRequired().HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<ScoutingReport>(entity =>
            {
                entity.ToTable("ScoutingReport", "dbo");

                entity.HasKey(e => e.ScoutingReportKey).HasName("PK_ScoutingReport");
                entity.Property(e => e.ScoutId)
                      .IsRequired()
                      .HasColumnType("nvarchar")
                      .HasMaxLength(450);

                entity.Property(e => e.PlayerKey).HasColumnType("int");
                entity.Property(e => e.TeamKey).HasColumnType("int");

                entity.Property(e => e.Defense)
                      .HasColumnType("int")
                      .HasColumnName("DefenseRating");

                entity.Property(e => e.Rebound)
                      .HasColumnType("int")
                      .HasColumnName("ReboundRating");

                entity.Property(e => e.Shooting).HasColumnType("int").HasColumnName("ShootingRating");
                entity.Property(e => e.Assist).HasColumnType("int").HasColumnName("AssistRating");
                entity.Property(e => e.Comments).HasColumnType("varchar");

                entity.Property(e => e.Created)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsCurrent)
                      .HasColumnType("bit")
                      .HasDefaultValueSql("((1))");
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