using Microsoft.AspNetCore.Mvc;
using JeweleryStorePlatformService.Interface;
using JeweleryStorePlatformBusinessObject.Jewelery;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JeweleryController : ControllerBase
    {
        private readonly IJeweleryService _jeweleryService;

        public JeweleryController(IJeweleryService jeweleryService)
        {
            _jeweleryService = jeweleryService;
        }

        // GET: api/Jewelry
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<JeweleryEntity>>> GetAll()
        {
            try
            {
                var jewelries = await _jeweleryService.GetAll();
                return Ok(jewelries);
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ và trả về lỗi
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Jewelery/5
        [HttpGet("{jeweleryId}")]
        public async Task<ActionResult<JeweleryEntity>> GetById(int jeweleryId)
        {
            try
            {
                var jewelery = await _jeweleryService.GetById(jeweleryId);
                if (jewelery == null)
                {
                    return BadRequest("Cannot find jewelery");
                }
                return Ok(jewelery);
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ và trả về lỗi
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: api/Jewelry
        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create([FromBody] JeweleryCreateRequest request)
        {
            try
            {
                var jeweleryId = await _jeweleryService.Create(request);
                if (jeweleryId == 0)
                    return BadRequest();

                var jewelery = await _jeweleryService.GetById(jeweleryId);
                if (jewelery == null)
                    return NotFound();

                // Return a message indicating successful creation
                return CreatedAtAction(nameof(GetById), new { id = jeweleryId }, jewelery);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Jewelry/5
        [HttpPut("{jeweleryId}")]
        public async Task<ActionResult<int>> Update(int jeweleryId, [FromBody] JeweleryUpdateRequest request)
        {
            try
            {
                request.Id = jeweleryId; // Ensure the ID from route matches the request
                var result = await _jeweleryService.Update(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Jewelry/5
        [HttpDelete("{jeweleryId}")]
        public async Task<ActionResult<int>> Delete(int jeweleryId)
        {
            try
            {
                var result = await _jeweleryService.Delete(jeweleryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
