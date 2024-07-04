using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JeweleryStorePlatformAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAccounts()
    {
        return Ok(await _accountService.GetAllAccounts());
    }
}