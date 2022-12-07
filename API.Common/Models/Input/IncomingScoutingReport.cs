namespace API.Common.Models.Input
{
    /// <summary>
    /// This class represents an incoming scouting report.
    /// </summary>
    public class IncomingScoutingReport
    {
        /// <summary>
        /// Gets or sets the name of the scout.
        /// </summary>
        public string ScoutName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the shooting rating.
        /// </summary>
        public int ShootingRating { get; set; }

        /// <summary>
        /// Gets or sets the defensive rating.
        /// </summary>
        public int DefenseRating { get; set; }

        /// <summary>
        /// Gets or sets the assist rating.
        /// </summary>
        public int AssistRating { get; set; }

        /// <summary>
        /// Gets or sets the rebound rating.
        /// </summary>
        public int ReboundRating { get; set; }

        /// <summary>
        /// Gets or sets the necessary comments.
        /// </summary>
        public string Comments { get; set; } = null!;
    }
}