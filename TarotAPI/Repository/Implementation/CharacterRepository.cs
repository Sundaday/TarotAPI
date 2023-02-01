using Microsoft.EntityFrameworkCore;
using TarotAPI.Data;
using TarotAPI.Models;
using TarotAPI.Repository.Interface;

namespace TarotAPI.Repository.Implementation
{
    public class CharacterRepository : IRepository<Character>
    {
        private readonly ApplicationDbContext _context;

        public CharacterRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Character>> GetAll()
        {
            try
            {
                return await _context.Characters.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Character> GetById(int id)
        {
            try
            {
                Character? character = new Character();
                character = await _context.Characters.FirstOrDefaultAsync(c => c.CharacterId == id);
                return character;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Character> Add(Character entity)
        {
            try
            {
                await _context.Characters.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Character> Update(Character entity)
        {
            try
            {
                _context.Characters.Update(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<bool> Delete(Character entity)
        {
            try
            {
                _context.Characters.Remove(entity);
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