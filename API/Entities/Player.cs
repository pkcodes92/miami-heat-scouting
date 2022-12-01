using System;

namespace API.Entities
{
    public class Player
    {
        public int PlayerKey { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int? PositionKey { get; set; }
        public int? AgentKey { get; set; }
        public int? FreeAgentYear { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public int? YearsOfService { get; set; }
        public decimal? Wing { get; set; }
        public decimal? BodyFat { get; set; }
        public decimal? StandingReach { get; set; }
        public decimal? CourtRunTime { get; set; }
        public decimal? VerticalJumpNoStep { get; set; }
        public decimal? VerticalJumpMax { get; set; }
        public decimal? HandWidth { get; set; }
        public decimal? HandLength { get; set; }
        public string URLPhoto { get; set; } = null!;
        public bool ActiveAnalysisFlag { get; set; }
        public int? LeagueCustomGroupKey { get; set; }
        public int? BboPlayerKey { get; set; }
        public DateTime InsertDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public string AgentName { get; set; } = null!;
        public string AgentPhone { get; set; } = null!;
        public string CommittedTo { get; set; } = null!;
        public string Handedness { get; set; } = null!;
        public int? GLPlayerKey { get; set; }
        public int? PlayerStatusKey { get; set; }
        public string HeightSource { get; set; } = null!;
        public string WeightSource { get; set; } = null!;
        public string WingSource { get; set; } = null!;
        public string BodyFatSource { get; set; } = null!;
        public string StandingReachSource { get; set; } = null!;
    }
}