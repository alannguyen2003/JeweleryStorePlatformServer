using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace JeweleryStorePlatformService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IConfiguration _config;

        public AccountService(IAccountRepository accountRepository, IConfiguration configuration, IAccountRoleRepository accountRoleRepository)
        {
            _accountRepository = accountRepository;
            _config = configuration;
            _accountRoleRepository = accountRoleRepository;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            return await _accountRepository.GetAllAccounts();
        }

        public async Task AddNewAccount(Account account)
        {
            await _accountRepository.AddNewAccount(account);
        }

        public async Task AddRangeAccount(List<Account> accounts)
        {
            await _accountRepository.AddRangeAccount(accounts);
        }

        public Account CheckLogin(string email, string password)
        {
            return _accountRepository.CheckLogin(email, password);
        }

        public string GenerateJwtToken(Account account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            int roleId = _accountRoleRepository.GetRoleIdByAccountId(account.Id);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                new Claim[]
                {
                new Claim(ClaimTypes.Email, account.Email),
                new Claim("RoleId", roleId.ToString()),
                new Claim("AccountId", account.Id.ToString()),
                },
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Account> Register(Account account)
        {
            await _accountRepository.AddNewAccount(account);
            return account;
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            return await _accountRepository.UpdateAccount(account);
        }

        public async Task<bool> DeleteAccount(int accountId)
        {
            return await _accountRepository.DeleteAccount(accountId);
        }

        public async Task<Account> GetAccountById(int accountId)
        {
            return await _accountRepository.GetAccountById(accountId);
        }

        public int GetRoleIdByAccountId(int accountId)
        {
            return _accountRepository.GetRoleIdByAccountId(accountId);
        }
    }
}
