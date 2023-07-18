using ArmoryPet.Core.Actions;
using ArmoryPet.Core.Interfaces;
using ArmoryPet.Core.Models;
using ArmoryPet.Infrastructure.Dto;
using ArmoryPet.Infrastructure.Interfaces;
using AutoMapper;

namespace ArmoryPet.Core.Services;

public class WarmaneService : IWarmaneService
{
    private readonly IWarmaneClientApi _warmaneClientApi;
    private readonly IDatabaseActionsService _databaseActionsService;
    public WarmaneService(IWarmaneClientApi warmaneClientApi, IDatabaseActionsService databaseActionsService)
    {
        _warmaneClientApi = warmaneClientApi;
        _databaseActionsService = databaseActionsService;
    }

    public async Task<Character> GetCharacterAsync(string characterName, string server)
    {
        //изменение регистра вводимых данных to (Search, Icecrown)
        var converterNameServer = new ChangeRegisterNameServer();
        var convertedNames= converterNameServer.Convert(characterName, server);
        //попытка взять персонажа с бд, если в бд нет, получаем с апи и записываем в бд
        var characterFromDb = await _databaseActionsService.GetCharacterByNameAsync(convertedNames.Item1, convertedNames.Item2);
        if (characterFromDb == null)
        {
            var characterFromApi = await _warmaneClientApi.GetCharacterAsync(convertedNames.Item1, convertedNames.Item2);
            //character core to characterDto database
            if (!string.IsNullOrEmpty(characterFromApi?.Name))
            {
                var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Character, CharacterDto>()));
                CharacterDto characterDto = mapper.Map<CharacterDto>(characterFromApi);
                await _databaseActionsService.AddAsync(characterDto);
                return characterFromApi;
            }
            else
            {
                return characterFromApi!;
            }
        }
        else
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CharacterDto, Character>()));
            return mapper.Map<Character>(characterFromDb);
        }
    }

    public async Task<IEnumerable<Character>> GetAllCharactersAsync()
    {
        var list =  await _databaseActionsService.GetAllCharactersAsync();
        var configuration = new MapperConfiguration(cfg => cfg.CreateMap<CharacterDto, Character>());
        return new Mapper(configuration).Map<IEnumerable<CharacterDto>, IEnumerable<Character>>(list);
    }


    public void DeleteCharacter(int characterId)
    {
        _databaseActionsService.Delete(characterId);
    }
}