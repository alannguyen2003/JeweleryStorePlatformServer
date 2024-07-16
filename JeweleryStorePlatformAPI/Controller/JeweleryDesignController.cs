using JeweleryStorePlatformDataTransfer.Responses;
using JeweleryStorePlatformService.DTOs;
using JeweleryStorePlatformService;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Mvc;
using Service.Models.Payload.Requests.Member;
using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformDataTransfer.Request.Diamond;
using JeweleryStorePlatformDataTransfer.Request;

namespace JeweleryStorePlatformAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class JeweleryDesignController : ControllerBase
    {
        private readonly IJeweleryDesignService _service;

        public JeweleryDesignController(IJeweleryDesignService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<Result<List<JeweleryDesign>>>> GetAll()
        {
            var designs = await _service.GetAllJeweleryDesign();
            return Ok(Result<List<JeweleryDesign>>.Succeed(designs));
        }

        [HttpPost]
        public async Task<ActionResult<Result<JeweleryDesign>>> CreateJeweryDesign([FromForm] CreateJeweleryDesignRequest request)
        {
            var entity = await _service.AddNewJeweleryDesign(request);
            return CreatedAtAction(nameof(CreateJeweryDesign), new { id = entity.Id }, Result<JeweleryDesign>.Succeed(entity));
        }
    }
}
