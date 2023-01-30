using TarotAPI.Models;

namespace TarotAPI.Repository.Interface
{
    public interface IGuildRepository
    {
        Task<List<Guild>> GetGuilds();
    }
}