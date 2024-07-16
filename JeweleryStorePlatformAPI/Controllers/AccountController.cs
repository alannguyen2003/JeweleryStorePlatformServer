using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Mvc;
using JeweleryStorePlatformBusinessObject.Account;
using System.Threading.Tasks;

namespace JeweleryStorePlatformAPI.Controller
{
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest("Invalid account data.");
            }

            var createdAccount = await _accountService.Register(account);
            return CreatedAtAction(nameof(GetAccountById), new { id = createdAccount.Id }, createdAccount);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAccount([FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest("Invalid account data.");
            }

            var updatedAccount = await _accountService.UpdateAccount(account);
            return Ok(updatedAccount);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var result = await _accountService.DeleteAccount(id);
            if (!result)
            {
                return NotFound("Account not found.");
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var account = await _accountService.GetAccountById(id);
            if (account == null)
            {
                return NotFound("Account not found.");
            }

            return Ok(account);
        }
    }
}
