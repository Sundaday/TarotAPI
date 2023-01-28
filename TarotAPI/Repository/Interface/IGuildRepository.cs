using TarotAPI.Models;

namespace TarotAPI.Repository.Contract
{
    public interface IGuildRepository
    {
        Task<List<Guild>> GetGuilds();
    }
}