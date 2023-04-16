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


        // when adding any new set, perform the following commands to update the database and add a table
        // dotnet ef migrations add [insert-migration-name]
        // dotnet ef database update
        public DbSet<JournalEntryData> JournalEntries { get; set; }
        public DbSet<UserData> UserInfo { get; set; }
    }

}
