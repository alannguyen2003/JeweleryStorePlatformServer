using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataTransfer.Request.JewelerysDTO;
using JeweleryStorePlatformService;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JeweleryStorePlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JeweleryCaseController : ControllerBase
    {
        private readonly IJeweleryCaseService _jeweleryCaseService;

        public JeweleryCaseController(IJeweleryCaseService jeweleryCaseService)
        {
            _jeweleryCaseService = jeweleryCaseService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<JeweleryCase>>> GetAll()
        {
            try
            {
                var jeweleries = await _jeweleryCaseService.GetAll();
                return Ok(jeweleries);
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ và trả về lỗi
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{jewelerycaseId}")]
        public async Task<ActionResult<JeweleryCase>> GetById(int jeweleryId)
        {
            try
            {
                var jewelery = await _jeweleryCaseService.GetById(jeweleryId);
                if (jewelery == null)
                {
                    return BadRequest("Cannot find jewelery case");
                }
                return Ok(jewelery);
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ và trả về lỗi
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create([FromBody] JeweleryCaseDTO request)
        {
            try
            {
                var jewelerycaseId = await _jeweleryCaseService.Create(request);
                if (jewelerycaseId == 0)
                    return BadRequest();

                // Return a URI with the ID of the created jewelery
                return CreatedAtAction(nameof(GetById), new { jewelerycaseId = jewelerycaseId }, null);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{jeweleryId}")]
        public async Task<ActionResult<int>> Update(int jeweleryId, [FromBody] JeweleryCaseUpdateDTO request)
        {
            try
            {
                request.Id = jeweleryId; // Ensure the ID from route matches the request
                var result = await _jeweleryCaseService.Update(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{jeweleryId}")]
        public async Task<ActionResult<int>> Delete(int jeweleryId)
        {
            try
            {
                var result = await _jeweleryCaseService.Delete(jeweleryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
