using System.Security.Claims;
using JeweleryStorePlatformDataTransfer.Responses;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;

namespace JeweleryStorePlatformAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PayOS _payOs;
    private readonly IConfiguration _configuration;
    private readonly IOrderService _orderService;
    private readonly ITransactionService _transactionService;
    private readonly IOrderItemService _orderItemService;
    public PaymentController(IConfiguration configuration, IOrderService orderService,
        ITransactionService transactionService, IOrderItemService orderItemService)
    {
        _orderService = orderService;
        _configuration = configuration;
        _payOs = new PayOS(_configuration.GetSection("PayOS:ClientID").Value!,
            _configuration.GetSection("PayOS:ApiKey").Value!,
            _configuration.GetSection("PayOS:ChecksumKey").Value!);
        _transactionService = transactionService;
        _orderItemService = orderItemService;
    }

    [HttpGet("create-payment-link")]
    [Authorize]
    public async Task<IActionResult> CreatePaymentLink(int orderId)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var userId = Int32.Parse(identity.FindFirst("AccountId").Value);
        var transaction = await _transactionService.GetLatestTransactionByOrderId(userId, orderId);
        var listItem = new List<ItemData>()
        {
            new ItemData("Thanh toán đơn hàng", 1, 20000)
        };
        PaymentData paymentData = new PaymentData(orderId, 20000,
            "Cửa hàng Kim Cương", listItem,
            "http://localhost:3000/cancel-payment?transactionId=" + transaction.Id,
            "http://localhost:3000/success-payment?transactionId=" + transaction.Id);
        CreatePaymentResult createPaymentResult = await _payOs.createPaymentLink(paymentData);
        return Ok(new Result<CreatePaymentResult>()
        {
            Succeeded = true, 
            Data = createPaymentResult
        });
    }

}