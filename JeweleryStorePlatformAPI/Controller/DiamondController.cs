using JeweleryStorePlatformDataTransfer.Responses;
using JeweleryStorePlatformService;
using JeweleryStorePlatformService.DTOs;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Mvc;
using Service.Models.Payload.Requests.Member;

namespace JeweleryStorePlatformAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiamondController : ControllerBase
    {
        private readonly IDiamondService _service;

        public DiamondController(IDiamondService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<DiamondDTO>>>> GetDiamonds([FromQuery] GetDiamondsRequest request)
        {
            var diamonds = await _service.GetAllDiamonds(request);
            return Ok(Result<PaginatedList<DiamondDTO>>.Succeed(diamonds));
        }
    }
}
