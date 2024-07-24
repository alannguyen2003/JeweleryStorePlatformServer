using JeweleryStorePlatformDataTransfer;
using JeweleryStorePlatformDataTransfer.Request.AccountDTO;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace JeweleryStorePlatformAPI.Controller;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IAccountRoleRepository _accountRoleRepository;
    public AuthenticationController(IAccountService accountService, IAccountRoleRepository accountRoleRepository)
    {
        _accountService = accountService;
        _accountRoleRepository = accountRoleRepository;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] AccountsDTO request)
    {
        if (request == null)
        {
            return BadRequest(new ApiResponse
            {
                StatusCode = 400,
                Message = "Invalid client request",
                Data = null,
                RoleId = 0
            });
        }

        var account = _accountService.CheckLogin(request.Email, request.Password);
        if (account == null)
        {
            return Unauthorized(new ApiResponse
            {
                StatusCode = 401,
                Message = "Unauthorized",
                Data = null,
                RoleId = 0
            });
        }

        var token = _accountService.GenerateJwtToken(account);
        var roleId = await _accountService.GetRoleIdByAccountId(account.Id);
        return Ok(new ApiResponse
        {
            StatusCode = 200,
            Message = "Login successful",
            Data = token,
            RoleId = roleId
        });
    }
}