using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class AccountRoleRepository : IAccountRoleRepository
    {
        public int GetRoleIdByAccountId(int accountId)
        {
            return AccountRoleDAO.Instance.GetRoleIdByAccountId(accountId);
        }
    }
}
