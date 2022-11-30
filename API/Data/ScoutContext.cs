using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ScoutContext : DbContext
    {
        /// <summary>
        /// This is the default constructor for the Scout context class.
        /// </summary>
        /// <param name="options">SQL Server DB Options.</param>
        /// <returns>An instance for the database connection.</returns>
        public ScoutContext(DbContextOptions options) : base(options)
        {
        }
    }
}