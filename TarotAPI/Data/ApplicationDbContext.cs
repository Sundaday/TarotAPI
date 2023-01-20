using Microsoft.EntityFrameworkCore;
using TarotAPI.Models;

namespace TarotAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<UserOld> Users { get; set; }
        public DbSet<GuildOld> Guilds { get; set; }
        public DbSet<CharacterOld> Characters { get; set; }
        public DbSet<TeamOld> Teams { get; set; }
    }
}
