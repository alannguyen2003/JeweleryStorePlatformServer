using System.Security.Claims;
using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformDataTransfer.Request.OrderItemsDTO;
using JeweleryStorePlatformDataTransfer.Request.OrdersDTO;
using JeweleryStorePlatformDataTransfer.Responses;
using JeweleryStorePlatformService;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [HttpGet("GetByAccountId")]
    [Authorize]
    public async Task<IActionResult> GetByAccountId()
    {
        try
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = Int32.Parse(identity.FindFirst("AccountId").Value);
            var orders = await _orderService.GetOrderByAccountId(userId);
            return Ok(new Result<List<Order>>()
            {
                Succeeded = true, 
                Data = orders
            });
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
    [Authorize]
    public async Task<IActionResult> Create([FromBody] OrderDTO request)
    {
        try
        {
            var orderId = await _orderService.Create(HttpContext.User, request);
            if (orderId == 0)
                return BadRequest();
            // Return a URI with the ID of the created jewelery
            return Ok(new Result<int>()
            {
                Succeeded = true,
                Message = "Create new order successful!",
                Data = orderId
            });
        }
        catch (Exception ex)
        {
            // Handle exceptions and return error
            return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
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

    [Authorize]
    [HttpGet("accepted-order")]
    public async Task<IActionResult> AcceptedOrder(int orderId)
    {
        try
        {
            await _orderService.AcceptedOrder(orderId);
            return Ok(new Result<string>()
            {
                Succeeded = true,
                Message = "Order has been accepted!"
            });
        }
        catch (Exception ex)
        {
            return Ok(ex.InnerException);
        }
    }
}