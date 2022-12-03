// <copyright file="Player.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Entities
{
    /// <summary>
    /// This file represents the player entity.
    /// </summary>
    public partial class Player
    {
        /// <summary>
        /// Gets or sets the primary key of the player entity.
        /// </summary>
        public int PlayerKey { get; set; }

        /// <summary>
        /// Gets or sets the first name of the player.
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the last name of the player.
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the birth date of the player.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the position of the player.
        /// </summary>
        public int? PositionKey { get; set; }

        /// <summary>
        /// Gets or sets the agent of the player.
        /// </summary>
        public int? AgentKey { get; set; }

        /// <summary>
        /// Gets or sets the free agent year for the player.
        /// </summary>
        public int? FreeAgentYear { get; set; }

        /// <summary>
        /// Gets or sets the height of the player.
        /// </summary>
        public decimal? Height { get; set; }

        /// <summary>
        /// Gets or sets the weight of the player.
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// Gets or sets the years of service that the player has been in the NBA.
        /// </summary>
        public int? YearsOfService { get; set; }

        /// <summary>
        /// Gets or sets the wingspan of the player.
        /// </summary>
        public decimal? Wing { get; set; }

        /// <summary>
        /// Gets or sets the body fat of the player.
        /// </summary>
        public decimal? BodyFat { get; set; }

        /// <summary>
        /// Gets or sets the standing reach of the player.
        /// </summary>
        public decimal? StandingReach { get; set; }

        /// <summary>
        /// Gets or sets the court run time of the player.
        /// </summary>
        public decimal? CourtRunTime { get; set; }

        /// <summary>
        /// Gets or sets the vertical jump of the player.
        /// </summary>
        public decimal? VerticalJumpNoStep { get; set; }

        /// <summary>
        /// Gets or sets the maximum vertical jump of the player.
        /// </summary>
        public decimal? VerticalJumpMax { get; set; }

        /// <summary>
        /// Gets or sets the hand width of the player.
        /// </summary>
        public decimal? HandWidth { get; set; }

        /// <summary>
        /// Gets or sets the hand length of the player.
        /// </summary>
        public decimal? HandLength { get; set; }

        /// <summary>
        /// Gets or sets the url photo of the player.
        /// </summary>
        public string URLPhoto { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating whether or not the player is actively analyzed.
        /// </summary>
        public bool ActiveAnalysisFlag { get; set; }

        /// <summary>
        /// Gets or sets the league custom group key of the player.
        /// </summary>
        public int? LeagueCustomGroupKey { get; set; }

        /// <summary>
        /// Gets or sets the Basketball Operations key of the player.
        /// </summary>
        public int? BboPlayerKey { get; set; }

        /// <summary>
        /// Gets or sets the date/time that the data has been inserted.
        /// </summary>
        public DateTime InsertDateTime { get; set; }

        /// <summary>
        /// Gets or sets the date/time that the data was updated.
        /// </summary>
        public DateTime? UpdateDateTime { get; set; }

        /// <summary>
        /// Gets or sets the name of the agent.
        /// </summary>
        public string AgentName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the phone number of the agent.
        /// </summary>
        public string AgentPhone { get; set; } = null!;

        /// <summary>
        /// Gets or sets which organization there is a commitment made towards.
        /// </summary>
        public string CommittedTo { get; set; } = null!;

        /// <summary>
        /// Gets or sets the handedness of the player.
        /// </summary>
        public string Handedness { get; set; } = null!;

        /// <summary>
        /// Gets or sets the GLPlayerKey.
        /// </summary>
        public int? GLPlayerKey { get; set; }

        /// <summary>
        /// Gets or sets the status key of the player.
        /// </summary>
        public int? PlayerStatusKey { get; set; }

        /// <summary>
        /// Gets or sets the height source.
        /// </summary>
        public string HeightSource { get; set; } = null!;

        /// <summary>
        /// Gets or sets the weight source.
        /// </summary>
        public string WeightSource { get; set; } = null!;

        /// <summary>
        /// Gets or sets the wingspan source.
        /// </summary>
        public string WingSource { get; set; } = null!;

        /// <summary>
        /// Gets or sets the source for the player's body fat content.
        /// </summary>
        public string BodyFatSource { get; set; } = null!;

        /// <summary>
        /// Gets or sets the source for the standing reach.
        /// </summary>
        public string StandingReachSource { get; set; } = null!;

        /// <summary>
        /// Gets or sets the source for the court run time.
        /// </summary>
        public string CourtRunTimeSource { get; set; } = null!;

        /// <summary>
        /// Gets or sets the source for the vertical jump.
        /// </summary>
        public string VerticalJumpNoStepSource { get; set; } = null!;

        /// <summary>
        /// Gets or sets the source for the max vertical jump.
        /// </summary>
        public string VerticalJumpMaxSource { get; set; } = null!;

        /// <summary>
        /// Gets or sets the source for the hand information, height, and weight.
        /// </summary>
        public string HandWHSource { get; set; } = null!;

        /// <summary>
        /// Gets or sets the hand.
        /// </summary>
        public string Hand { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating whether the data being provided is a custom data.
        /// </summary>
        public bool IsCustomData { get; set; }

        /// <summary>
        /// Gets or sets the source for the handedness attribute.
        /// </summary>
        public string HandednessSource { get; set; } = null!;
    }
}