using JeweleryStorePlatformRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class AccountRoleService : IAccountRoleRepository
    {
        private readonly IAccountRoleRepository _accountRoleRepository;

        public AccountRoleService(AccountRoleService accountRoleService)
        {
            _accountRoleRepository = accountRoleService;
        }

        public int GetRoleIdByAccountId(int accountId)
        {
            return _accountRoleRepository.GetRoleIdByAccountId(accountId);
        }
    }
}
