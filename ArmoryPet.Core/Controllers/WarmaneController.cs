using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmoryPet.Core.Interfaces;
using ArmoryPet.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArmoryPet.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarmaneController : ControllerBase

    {
        private readonly IWarmaneService _warmaneService;
        public WarmaneController(IWarmaneService warmaneService)
        {
            _warmaneService = warmaneService;
        }
        //получение коллекции чаров
        // GET: api/Warmane
        [HttpGet]
        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            return await _warmaneService.GetAllCharactersAsync();
        }

        //получение чара из бд (в отсутствии записи бд чар берется с апи, если персонажа не существует - null)
        // GET: api/Warmane/5
        [HttpGet("{name}/{server}", Name = "Get")]
        public async Task<Character> GetAsync(string name, string server)
        {
            return await _warmaneService.GetCharacterAsync(name, server);
        }
        
        // POST: api/Warmane
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Warmane/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Warmane/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
