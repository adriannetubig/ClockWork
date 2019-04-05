using Clockwork.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clockwork.Data
{
    public class ClockworkContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=clockwork.db");
        }
        public DbSet<CurrentTimeQuery> CurrentTimeQueries { get; set; }
    }
}
