namespace API.Services
{
    /// <summary>
    /// This class implements the methods defined in <see cref="ITeamsService"/>.
    /// </summary>
    public class TeamsService : ITeamsService
    {
        private readonly ScoutContext scoutContext;
        private readonly TelemetryClient telemetryClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamsService"/> class.
        /// </summary>
        /// <param name="scoutContext">The database layer being injected.</param>
        /// <param name="telemetryClient">The telemetry tracking injection.</param>
        public TeamsService(ScoutContext scoutContext, TelemetryClient telemetryClient)
        {
            this.scoutContext = scoutContext;
            this.telemetryClient = telemetryClient;
        }

        /// <summary>
        /// This method returns a list of all the active teams.
        /// </summary>
        /// <returns>The list of NBA teams.</returns>
        public async Task<List<Team>> GetActiveTeamsAsync()
        {
            List<Team> teams;

            try
            {
                teams = await this.scoutContext.Teams.Where(x => x.CurrentNBATeamFlag == true).Select(x => new Team
                {
                    TeamKey = x.TeamKey,
                    ArenaKey = x.ArenaKey,
                    CoachName = x.CoachName,
                    Conference = x.Conference,
                    CurrentNBATeamFlag = x.CurrentNBATeamFlag,
                    LeagueKey = x.LeagueKey,
                    SubConference = x.SubConference,
                    TeamCity = x.TeamCity,
                    TeamCountry = x.TeamCountry,
                    TeamName = x.TeamName,
                    TeamNickname = x.TeamNickname,
                    URLPhoto = x.URLPhoto,
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackException(ex);
                teams = null!;
            }

            return teams;
        }

        /// <summary>
        /// This method implementation returns all of the teams in the database.
        /// </summary>
        /// <returns>A list of all the teams.</returns>
        public async Task<List<Team>> GetAllTeamsAsync()
        {
            List<Team> teams;

            try
            {
                teams = await this.scoutContext.Teams.Select(x => new Team
                {
                    TeamKey = x.TeamKey,
                    LeagueKey = x.LeagueKey,
                    TeamName = x.TeamName,
                    CurrentNBATeamFlag = x.CurrentNBATeamFlag,
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackException(ex);
                teams = null!;
            }

            return teams;
        }
    }
}
