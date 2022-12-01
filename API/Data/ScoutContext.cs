using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class ScoutContext : DbContext
    {
        public ScoutContext()
        {
        }

        public ScoutContext(DbContextOptions<ScoutContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<League> Leagues {get;set;} = null!;
    }
}