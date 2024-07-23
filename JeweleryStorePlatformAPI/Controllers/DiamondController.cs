using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformDataTransfer.Request.Diamond;
using JeweleryStorePlatformDataTransfer.Responses;
using JeweleryStorePlatformService;
using JeweleryStorePlatformService.DTOs;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
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


        [HttpGet("AllDiamondswithGIAReport")]
        public async Task<ActionResult<Result<PaginatedList<GIAReportDTO>>>> GetAllDiamondswithGIAReport([FromQuery] GetDiamondsRequest request)
        {
            var diamonds = await _service.GetAllDiamondswithGIAReport(request);
            return Ok(Result<PaginatedList<GIAReportDTO>>.Succeed(diamonds));
        }
        [HttpGet("AllDiamonds")]
        public async Task<ActionResult<Result<PaginatedList<DiamondDTO>>>> GetAllDiamonds([FromQuery] GetDiamondsRequest request)
        {
            var diamonds = await _service.GetAllDiamonds(request);
            return Ok(Result<PaginatedList<DiamondDTO>>.Succeed(diamonds));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<DiamondDTO>>> GetDiamondById(int id)
        {
            var diamond = await _service.GetDiamondById(id);
            return Ok(Result<DiamondDTO>.Succeed(diamond));
        }

        [HttpPost]
        public async Task<ActionResult<Result<DiamondDTO>>> CreateDiamond([FromBody] CreateDiamondRequest request)
        {
            var diamond = await _service.CreateDiamond(request);
            return CreatedAtAction(nameof(GetDiamondById), new { id = diamond.Id }, Result<DiamondDTO>.Succeed(diamond));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<DiamondDTO>>> UpdateDiamond(int id, [FromBody] UpdateDiamondRequest request)
        {
            var diamond = await _service.UpdateDiamond(id, request);
            return Ok(Result<DiamondDTO>.Succeed(diamond));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteDiamond(int id)
        {
            var result = await _service.DeleteDiamond(id);
            return Ok(Result<bool>.Succeed(result));
        }
    }
}
