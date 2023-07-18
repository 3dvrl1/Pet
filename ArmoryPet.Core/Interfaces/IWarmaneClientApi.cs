using ArmoryPet.Core.Models;

namespace ArmoryPet.Core.Interfaces;

public interface IWarmaneClientApi
{
    public Task<Character?> GetCharacterAsync(string name, string server);
}