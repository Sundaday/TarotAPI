using TarotAPI.Models;

namespace TarotAPI.Repository.Interface
{
    internal interface IUserRepository
    {
        Task<User> GetByGuild(User user);
    }
}