using ArmoryPet.Core.Interfaces;
using ArmoryPet.Core.Models;
using ArmoryPet.Infrastructure;
using ArmoryPet.Infrastructure.Dto;
using ArmoryPet.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArmoryPet.Core.Services
{
    public class DatabaseActionsService : IDatabaseActionsService
    {
        private readonly DatabaseContext _dbContext;
        
        public DatabaseActionsService(DatabaseContext dbContext)
        {
            _dbContext= dbContext;
        }
        public async Task AddAsync(CharacterDto characterDto)
        {
            if (!_dbContext.Characters.Any(p => p.Name == characterDto.Name & p.Realm == characterDto.Realm))
            {
                _dbContext.Characters.Add(characterDto);
                await _dbContext.SaveChangesAsync();
            }
            
            
        }

        public async Task<CharacterDto?> GetCharacterByNameAsync(string characterName, string serverName)
        {
            return await _dbContext.Characters.Where(p => p.Name == characterName && p.Realm == serverName)
                .FirstOrDefaultAsync();

        }

        public void Delete(int characterId)
        {
            var characterList = _dbContext.Characters.ToList();
            var character = characterList.Find(c => c.Id == characterId);
            if (character != null)
            {
                _dbContext.Characters.Remove(character);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task<IEnumerable<CharacterDto>> GetAllCharactersAsync()
        {
            return await _dbContext.Characters.ToListAsync();
        }
    }
}
