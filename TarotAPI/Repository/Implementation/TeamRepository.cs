using Microsoft.EntityFrameworkCore;
using TarotAPI.Data;
using TarotAPI.Models;
using TarotAPI.Repository.Interface;

namespace TarotAPI.Repository.Implementation
{
    public class TeamRepository : IRepository<Team>
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            try
            {
                List<Team> teams = new List<Team>();
                teams = await _context.Teams.ToListAsync();
                return teams;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Team> GetById(int id)
        {
            try
            {
                Team? team = new Team();
                team = await _context.Teams.FirstOrDefaultAsync(c => c.TeamId == id);
                return team;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Team> Add(Team entity)
        {
            try
            {
                await _context.Teams.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Team> Update(Team entity)
        {
            try
            {
                _context.Teams.Update(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<bool> Delete(Team entity)
        {
            try
            {
                _context.Teams.Remove(entity);
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