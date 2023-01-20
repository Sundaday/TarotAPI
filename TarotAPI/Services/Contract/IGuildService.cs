using TarotAPI.Models;

namespace TarotAPI.Services.Contract
{
    public interface IGuildService
    {
        Task<List<Guild>> GetGuilds();
    }
}