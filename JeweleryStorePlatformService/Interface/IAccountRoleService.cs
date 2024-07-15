using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IAccountRoleService
    {
        public int GetRoleIdByAccountId(int accountId);
    }
}
