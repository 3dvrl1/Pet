using ArmoryPet.Core.Interfaces;
using ArmoryPet.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArmoryPet.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatiRuApiController : ControllerBase
    {
        private readonly IPlatiRuService _platiRuService;

        public PlatiRuApiController(IPlatiRuService platiRuService)
        {
            _platiRuService = platiRuService;
        }

        [HttpGet("{gameName}/{visibleOnly}", Name = "Things")]
        public async Task<GoodsList> Get(string gameName, int pageSize, int pageNum, bool visibleOnly)
        {
            return await _platiRuService.GetGoodsAsync(gameName, pageSize, pageNum, visibleOnly);
        }
    }
}
