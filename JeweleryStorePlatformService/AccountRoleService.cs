using JeweleryStorePlatformRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformService.Interface;

namespace JeweleryStorePlatformService
{
    public class AccountRoleService : IAccountRoleService
    {
        private readonly IAccountRoleRepository _accountRoleRepository;

        public AccountRoleService(IAccountRoleRepository accountRoleRepository)
        {
            _accountRoleRepository = accountRoleRepository;
        }

        public int GetRoleIdByAccountId(int accountId)
        {
            return _accountRoleRepository.GetRoleIdByAccountId(accountId);
        }

        public async Task<List<AccountRole>> GetAllAccountRole()
        {
            return await _accountRoleRepository.GetAllAccountRole();
        }

        public async Task AddNewAccountRole(AccountRole accountRole)
        {
            await _accountRoleRepository.AddNewAccountRole(accountRole);
        }

        public async Task AddRangeAccountRole(List<AccountRole> accountRoles)
        {
            await _accountRoleRepository.AddRangeAccountRole(accountRoles);
        }
    }
}
