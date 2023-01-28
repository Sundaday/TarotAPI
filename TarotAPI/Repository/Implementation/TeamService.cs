using Microsoft.EntityFrameworkCore;
using TarotAPI.Data;
using TarotAPI.Models;
using TarotAPI.Services.Contract;

namespace TarotAPI.Repository.Implementation
{
    public class TeamService : ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetTeamsList()
        {
            try
            {
                List<Team> teams = new List<Team>();
                teams = await _context.Teams.ToListAsync();
                return teams;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Team>> GetTeamsWithCharactersList(int id)
        {
            try
            {
                List<Team> teams = new List<Team>();
                teams = await _context.Teams
                    .Where(i => i.UserId == id)
                    .Include(t => t.Characters)
                    .ToListAsync();
                return teams;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Team> GetTeamById(int id)
        {
            try
            {
                Team? team = new Team();
                team = await _context.Teams.FirstOrDefaultAsync(c => c.TeamId == id);
                return team;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Team> CreateTeam(Team team)
        {
            try
            {
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();
                return team;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Team> UpdateTeam(Team team)
        {
            try
            {
                _context.Teams.Update(team);
                await _context.SaveChangesAsync();
                return team;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteTeam(Team team)
        {
            try
            {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}