using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformDataTransfer.Request.OrderItemsDTO;
using JeweleryStorePlatformService;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JeweleryStorePlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<OrderItem>>> GetAll()
        {
            try
            {
                var orderitem = await _orderItemService.GetAll();
                return Ok(orderitem);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create([FromBody] OrderItemDTO request)
        {
            try
            {
                var orderId = await _orderItemService.Create(request);
                if (orderId == 0)
                    return BadRequest();

                // Return a URI with the ID of the created jewelery
                return CreatedAtAction(nameof(GetAll), new { orderId = orderId }, null);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{orderItemId}")]
        public async Task<ActionResult<int>> Delete(int orderItemId)
        {
            try
            {
                var result = await _orderItemService.Delete(orderItemId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
