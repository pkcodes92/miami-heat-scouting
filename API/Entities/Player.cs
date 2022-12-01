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
    }
}