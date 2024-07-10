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
        public async Task<ActionResult<List<Jewelery>>> GetAll()
        {
            try
            {
                var jeweleries = await _jeweleryService.GetAll();
                return Ok(jeweleries);
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ và trả về lỗi
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Jewelery/5
        [HttpGet("{jeweleryId}")]
        public async Task<ActionResult<Jewelery>> GetById(int jeweleryId)
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

        // POST: api/Jewelery/Create
        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create([FromBody] JeweleryCreateRequest request)
        {
            try
            {
                var jeweleryId = await _jeweleryService.Create(request);
                if (jeweleryId == 0)
                    return BadRequest();

                // Return a URI with the ID of the created jewelery
                return CreatedAtAction(nameof(GetById), new { jeweleryId = jeweleryId }, null);
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
