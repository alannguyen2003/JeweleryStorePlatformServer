using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformDataTransfer.Request.OrderItemsDTO;
using JeweleryStorePlatformDataTransfer.Request.OrdersDTO;
using JeweleryStorePlatformService;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JeweleryStorePlatformAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<Order>>> GetAll()
    {
        try
        {
            var order = await _orderService.GetAll();
            return Ok(order);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet("GetByAccountId/{accountId}")]
    public async Task<ActionResult<List<Order>>> GetByAccountId(int accountId)
    {
        try
        {
            var orders = await _orderService.GetOrderByAccountId(accountId);
            return Ok(orders);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("GetByIdAndAccountId/{orderId}/{accountId}")]
    public async Task<ActionResult<Order>> GetByIdAndAccountId(int orderId, int accountId)
    {
        try
        {
            var order = await _orderService.GetOrderByIdAndAccountId(orderId, accountId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost("Create")]
    public async Task<ActionResult<int>> Create([FromBody] OrderDTO request)
    {
        try
        {
            var orderId = await _orderService.Create(request);
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
    [HttpDelete("{orderId}")]
    public async Task<ActionResult<int>> Delete(int orderId)
    {
        try
        {
            var result = await _orderService.Delete(orderId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpPut("ChangStatus{orderId}")]
    public async Task<ActionResult<int>> ChangStatus(int orderId, int status)
    {
        try
        {
            var result = await _orderService.ChangStatus(orderId, status);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}