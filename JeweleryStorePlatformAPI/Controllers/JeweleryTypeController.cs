using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataTransfer.Responses;
using JeweleryStorePlatformService.DTOs;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Mvc;
namespace JeweleryStorePlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JeweleryTypeController : ControllerBase
    {

        private readonly IJeweleryTypeService _jeweleryTypeService;

        public JeweleryTypeController(IJeweleryTypeService jeweleryTypeService)
        {
            _jeweleryTypeService = jeweleryTypeService;
        }

        // GET: api/JeweleryType/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllJeweleryTypes([FromQuery] GetJeweleryTypesRequest request)
        {
            var result = await _jeweleryTypeService.GetAllJeweleryTypes(request);
            return Ok(result);
        }

        // GET: api/JeweleryType/{id}
        [HttpGet("{jeweleryTypeId}")]
        public async Task<ActionResult<JeweleryType>> GetById(int jeweleryTypeId)
        {
            try
            {
                var jeweleryType = await _jeweleryTypeService.GetJeweleryTypeById(jeweleryTypeId);
                if (jeweleryType == null)
                {
                    return NotFound("Cannot find jewelery type");
                }
                return Ok(jeweleryType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: api/JeweleryType/Create
        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create([FromBody] JeweleryTypeCreateRequest request)
        {
            try
            {
                var jeweleryType = new JeweleryType
                {
                    TypeName = request.TypeName,
                    // Set other properties as needed
                };
                var jeweleryTypeId = await _jeweleryTypeService.CreateJeweleryType(jeweleryType);

                return CreatedAtAction(nameof(GetById), new { jeweleryTypeId = jeweleryTypeId }, jeweleryType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/JeweleryType/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Result<JeweleryTypeDTO>>> UpdateJeweleryType(int id, [FromBody] JeweleryTypeUpdateRequest request)
        {
            try
            {
                // Gọi dịch vụ để cập nhật loại trang sức
                var jeweleryTypeDTO = await _jeweleryTypeService.UpdateJeweleryType(id, request);

                if (jeweleryTypeDTO == null)
                {
                    return NotFound("Cannot find jewelery type");
                }

                // Trả về kết quả thành công với DTO đã cập nhật
                return Ok(Result<JeweleryTypeDTO>.Succeed(jeweleryTypeDTO));
            }
            catch (Exception ex)
            {
                // Trả về lỗi 500 nếu có lỗi xảy ra
                return StatusCode(StatusCodes.Status500InternalServerError, "Cannot find jewelery type");
            }
        }


        // DELETE: api/JeweleryType/{id}
        [HttpDelete("{jeweleryTypeId}")]
        public async Task<ActionResult<int>> Delete(int jeweleryTypeId)
        {
            try
            {
                var jeweleryType = await _jeweleryTypeService.GetJeweleryTypeById(jeweleryTypeId);
                if (jeweleryType == null)
                {
                    return NotFound("Cannot find jewelery type");
                }

                await _jeweleryTypeService.DeleteJeweleryType(jeweleryTypeId);

                return Ok(jeweleryTypeId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

}

