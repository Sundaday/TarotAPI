using TarotAPI.Models;

namespace TarotAPI.Services.Contract
{
    public interface ICharacterService
    {
        Task<List<Character>> GetCharacters();
        Task<Character> CreateCharacter(Character character);
        Task<Character> UpdateCharacter(Character character);
    }
}
