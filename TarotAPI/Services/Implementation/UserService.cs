using Microsoft.EntityFrameworkCore;
using TarotAPI.Context;
using TarotAPI.Models;
using TarotAPI.Services.Contract;

namespace TarotAPI.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUserList()
        {
            try
            {
                List<User> users = new List<User>();
                users = await _context.Users.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<User> GetUserById(int id)
        {
            try
            {
                User? user = new User();
                user = await _context.Users.FirstOrDefaultAsync(c => c.UserId == id);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<User>> GetUserListWithGuild()
        {
            try
            {
                List<User> users = new List<User>();
                users = await _context.Users
                    .Include(g => g.Guild)
                    .ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<User> GetUserByIdWithGuild(int id)
        {
            try
            {
                User? user = new User();
                user = await _context.Users
                    .Include(c => c.Guild)
                    .FirstOrDefaultAsync(c => c.UserId == id);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<User> AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<User> UpdateUser(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteUser(User user)
        {
            try
            {
                _context.Users.Remove(user);
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