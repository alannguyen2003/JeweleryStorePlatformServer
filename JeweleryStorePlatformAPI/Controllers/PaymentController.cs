using Microsoft.AspNetCore.Mvc;
using Net.payOS;

namespace JeweleryStorePlatformAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PayOS _payOs;
    
}