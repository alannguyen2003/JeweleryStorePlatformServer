using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeweleryStorePlatformBusinessObject.Account;

namespace JeweleryStorePlatformRepository
{
    public class AccountRoleRepository : IAccountRoleRepository
    {
        public int GetRoleIdByAccountId(int accountId)
        {
            return AccountRoleDAO.Instance.GetRoleIdByAccountId(accountId);
        }

        public async Task<List<AccountRole>> GetAllAccountRole()
        {
            return await AccountRoleDAO.Instance.GetAllAccount();
        }

        public async Task AddNewAccountRole(AccountRole accountRole)
        {
            await AccountRoleDAO.Instance.AddNewAccountRole(accountRole);
        }

        public async Task AddRangeAccountRole(List<AccountRole> accountRoles)
        {
            await AccountRoleDAO.Instance.AddRangeAccountRole(accountRoles);
        }
    }
}
