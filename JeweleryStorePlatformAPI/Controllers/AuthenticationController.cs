using JeweleryStorePlatformDataTransfer;
using JeweleryStorePlatformDataTransfer.Request.AccountDTO;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace JeweleryStorePlatformAPI.Controller;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAccountService _accountService;
    public AuthenticationController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    /*    [HttpPost]
        [Route("Login")]
        public IActionResult<ApiResponse> Login([FromBody] AccountsDTO request)
        {
            var account = this._accountService.CheckLogin(request.Email, request.Password);
            if (account == null)
                return Unauthorized();

            var token = this._accountService.GenerateJwtToken(account);
            return Ok(ApiResponse);
        }*/

    [HttpPost]
    [Route("Login")]
    public IActionResult Login([FromBody] AccountsDTO request)
    {
        if (request == null)
        {
            return BadRequest(new ApiResponse
            {
                StatusCode = 400,
                Message = "Invalid client request",
                Data = null
            });
        }

        var account = _accountService.CheckLogin(request.Email, request.Password);
        if (account == null)
        {
            return Unauthorized(new ApiResponse
            {
                StatusCode = 401,
                Message = "Unauthorized",
                Data = null
            });
        }

        var token = _accountService.GenerateJwtToken(account);
        return Ok(new ApiResponse
        {
            StatusCode = 200,
            Message = "Login successful",
            Data = token
        });
    }
}