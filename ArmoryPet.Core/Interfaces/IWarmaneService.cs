using ArmoryPet.Core.Models;

namespace ArmoryPet.Core.Interfaces;

public interface IWarmaneService
{
    
    public Task<Character> GetCharacterAsync(string characterName, string server);
    public Task<IEnumerable<Character>> GetAllCharactersAsync();
    public void DeleteCharacter(int characterId);
}