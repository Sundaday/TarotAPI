using Microsoft.EntityFrameworkCore;
using TarotAPI.Context;
using TarotAPI.Models;
using TarotAPI.Services.Contract;

namespace TarotAPI.Services.Implementation
{
    public class GuildService : IGuildService
    {
        private readonly AppDbContext _context;

        public GuildService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Guild>> GetGuilds()
        {
            return await _context.Guilds.ToListAsync();
        }
    }
}