using Microsoft.EntityFrameworkCore;
using TarotAPI.Data;
using TarotAPI.Models;
using TarotAPI.Repository.Interface;

namespace TarotAPI.Repository.Implementation
{
    public class UserRepository : IRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<User> GetById(int id)
        {
            try
            {
                User? user = new User();
                user = await _context.Users.FirstOrDefaultAsync(c => c.UserId == id);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<User> Add(User entity)
        {
            try
            {
                _context.Users.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<User> Update(User entity)
        {
            try
            {
                _context.Users.Update(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<bool> Delete(User entity)
        {
            try
            {
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Task<User> GetByGuild(User user)
        {
            throw new NotImplementedException();
        }
    }
}