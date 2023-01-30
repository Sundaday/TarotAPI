using Microsoft.EntityFrameworkCore;
using TarotAPI.Data;
using TarotAPI.Models;
using TarotAPI.Repository.Interface;

namespace TarotAPI.Repository.Implementation
{
    public class GuildRepository : IGuildRepository
    {
        private readonly ApplicationDbContext _context;

        public GuildRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Guild>> GetGuilds()
        {
            return await _context.Guilds.ToListAsync();
        }
    }
}