namespace API.Entities
{
    public class Team
    {
        public int TeamKey { get; set; }
        public int? LeagueKey { get; set; }
        public int? LeagueKeyDomestic { get; set; }
        public int? ArenaKey { get; set; }
        public string TeamName { get; set; } = null!;
        public string TeamNickname { get; set; } = null!;
        public string Conference { get; set; } = null!;
        public string SubConference { get; set; } = null!;
        public string TeamCity { get; set; } = null!;
        public string TeamCountry { get; set; } = null!;
        public string CoachName { get; set; } = null!;
        public string URLPhoto { get; set; } = null!;
        public bool? CurrentNBATeamFlag { get; set; }
    }
}