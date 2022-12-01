namespace API.Entities
{
    public class League
    {
        public int LeagueKey { get; set; }
        public string LeagueName { get; set; } = null!;
        public string Country { get; set; } = null!;
        public bool ActiveSource { get; set; }
        public int LeagueGroupKey { get; set; }
        public int? LeagueCustomGroupKey { get; set; }
        public bool SearchDisplayFlag { get; set; }
    }
}