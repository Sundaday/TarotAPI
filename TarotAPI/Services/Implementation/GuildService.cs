using Microsoft.EntityFrameworkCore;
using TarotAPI.Data;
using TarotAPI.Models;
using TarotAPI.Services.Contract;

namespace TarotAPI.Services.Implementation
{
    public class GuildService : IGuildService
    {
        private readonly ApplicationDbContext _context;

        public GuildService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Guild>> GetGuilds()
        {
            return await _context.Guilds.ToListAsync();
        }
    }
}