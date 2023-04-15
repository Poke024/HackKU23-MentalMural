using Microsoft.EntityFrameworkCore;
using MentalMural.Shared;

namespace MentalMural.Server.Database.Data
{
    public class JournalEntryDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public JournalEntryDataContext(IConfiguration configuration, DbContextOptions<JournalEntryDataContext> options) : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("JournalEntryDB"));
        }

        public DbSet<JournalEntryData> JournalEntries { get; set; }
    }

}
