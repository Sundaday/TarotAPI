using Microsoft.EntityFrameworkCore;
using TarotAPI.Data;
using TarotAPI.Models;
using TarotAPI.Services.Contract;

namespace TarotAPI.Repository.Implementation
{
    public class CharacterService : ICharacterRepository
    {
        private readonly ApplicationDbContext _context;

        public CharacterService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Character>> GetCharacters()
        {
            return await _context.Characters.ToListAsync();
        }
        public async Task<Character> CreateCharacter(Character character)
        {
            try
            {
                _context.Characters.Add(character);
                await _context.SaveChangesAsync();
                return character;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Character> UpdateCharacter(Character character)
        {
            try
            {
                _context.Characters.Update(character);
                await _context.SaveChangesAsync();
                return character;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}