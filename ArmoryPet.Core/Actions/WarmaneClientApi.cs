using ArmoryPet.Core.Interfaces;
using ArmoryPet.Core.Models;
using RestSharp;

namespace ArmoryPet.Core.Actions;

public class WarmaneClientApi : IWarmaneClientApi
{
    public async Task<Character?> GetCharacterAsync(string characterName, string server)
    {
        var options = new RestClientOptions("https://armory.warmane.com/");
        var client = new RestClient(options);
        return await client.GetJsonAsync<Character?>($"api/character/{characterName}/{server}/summary");

    }
}