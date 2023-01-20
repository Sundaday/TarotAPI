using TarotAPI.Models;

namespace TarotAPI.Services.Contract
{
    public interface ITeamService
    {
        Task<List<Team>> GetTeamsList();
        Task<List<Team>> GetTeamsWithCharactersList(int id);
        Task<Team> GetTeamById(int id);
        Task<Team> CreateTeam(Team team);
        Task<Team> UpdateTeam(Team team);
        Task<bool> DeleteTeam(Team team);
    }
}