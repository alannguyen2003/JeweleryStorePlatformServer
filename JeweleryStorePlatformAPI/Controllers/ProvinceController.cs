using JeweleryStorePlatformService;
using Microsoft.AspNetCore.Mvc;

namespace JeweleryStorePlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinceController : ControllerBase
    {
      private readonly ProvinceService _provinceService;
        public ProvinceController (ProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        [HttpGet("fetch-and-store-data")]
        public async Task<IActionResult> FetchAndStoreData()
        {
            await _provinceService.FetchAndStoreDataAsync();
            return Ok("Data fetched and stored successfully.");
        }
    }
}
