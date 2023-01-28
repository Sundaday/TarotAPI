using TarotAPI.Models;

namespace TarotAPI.Repository.Contract
{
    public interface ICharacterRepository
    {
        Task<List<Character>> GetCharacters();
        Task<Character> CreateCharacter(Character character);
        Task<Character> UpdateCharacter(Character character);
    }
}
