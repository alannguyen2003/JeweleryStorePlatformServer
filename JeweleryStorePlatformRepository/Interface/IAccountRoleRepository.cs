using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IAccountRoleRepository
    {
        public int GetRoleIdByAccountId(int accountId);
    }
}
