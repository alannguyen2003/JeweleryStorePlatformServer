using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeweleryStorePlatformBusinessObject.Account;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IAccountRoleRepository
    {
        public int GetRoleIdByAccountId(int accountId);

        public Task<List<AccountRole>> GetAllAccountRole();
        public Task AddNewAccountRole(AccountRole accountRole);
        public Task AddRangeAccountRole(List<AccountRole> accountRoles);
    }
}
