using Microsoft.EntityFrameworkCore;
using TarotAPI.Data;
using TarotAPI.Models;
using TarotAPI.Repository.Interface;

namespace TarotAPI.Repository.Implementation
{
    public class GuildRepository : IRepository<Guild>
    {
        private readonly ApplicationDbContext _context;

        public GuildRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Guild>> GetAll()
        {
            try
            {
                return await _context.Guilds.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Guild> GetById(int id)
        {
            try
            {
                Guild? guild = new Guild();
                guild = await _context.Guilds.FirstOrDefaultAsync(c => c.GuildId == id);
                return guild;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Guild> Add(Guild entity)
        {
            try
            {
                await _context.Guilds.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Guild> Update(Guild entity)
        {
            try
            {
                _context.Guilds.Update(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<bool> Delete(Guild entity)
        {
            try
            {
                _context.Guilds.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}