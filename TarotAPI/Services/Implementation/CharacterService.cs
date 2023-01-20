using Microsoft.EntityFrameworkCore;
using TarotAPI.Context;
using TarotAPI.Models;
using TarotAPI.Services.Contract;

namespace TarotAPI.Services.Implementation
{
    public class CharacterService : ICharacterService
    {
        private readonly AppDbContext _context;

        public CharacterService(AppDbContext context)
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