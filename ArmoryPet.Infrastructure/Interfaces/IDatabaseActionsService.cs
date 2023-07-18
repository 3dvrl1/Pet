using ArmoryPet.Infrastructure.Dto;

namespace ArmoryPet.Infrastructure.Interfaces
{
    public interface IDatabaseActionsService
    {
        public  Task AddAsync(CharacterDto characterDto);
        public Task<CharacterDto?> GetCharacterByNameAsync(string characterName, string serverName);
        public void Delete(int characterId);
        public Task<IEnumerable<CharacterDto>> GetAllCharactersAsync();

    }
    
}
