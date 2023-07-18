using ArmoryPet.Core.Interfaces;
using ArmoryPet.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArmoryPet.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarmaneClientApiController : ControllerBase
    {
        private readonly IWarmaneService _warmaneService;
        public WarmaneClientApiController(IWarmaneService warmaneService)
        {
            _warmaneService = warmaneService;
        }
        // GET: api/WarmaneClientApi/Search/Icecrown
        [HttpGet("{characterName}/{realm}", Name = "Get")]
        public async Task<Character> Get(string characterName, string realm)
        {
            return await _warmaneService.GetCharacterAsync(characterName, realm);
        }

        [HttpDelete("{characterId}",Name = "DeleteById")]
        public async Task Delete(int characterId)
        {
            _warmaneService.DeleteCharacter(characterId);
        }
        
    }
}
