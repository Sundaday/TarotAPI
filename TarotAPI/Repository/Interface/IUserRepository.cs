using TarotAPI.Models;

namespace TarotAPI.Repository.Contract
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserList();
        Task<User> GetUserById(int id);
        Task<List<User>> GetUserListWithGuild();
        Task<User> GetUserByIdWithGuild(int id);
        Task<User> AddUser (User user);
        Task<User> UpdateUser (User user);
        Task<bool> DeleteUser (User user);
    }
}