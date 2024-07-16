using JeweleryStorePlatformBusinessObject.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class AccountRoleDAO
    {
        private readonly AppDbContext _context;
        private static AccountRoleDAO instance;

        public AccountRoleDAO()
        {
            _context = new AppDbContext();
        }

        public static AccountRoleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountRoleDAO();
                }
                return instance;
            }
        }

        public async Task<List<AccountRole>> GetAllAccount()
        {
            return await _context.AccountRoles.ToListAsync();
        }

        public async Task AddNewAccounRolet(AccountRole accountrole)
        {
            await _context.AccountRoles.AddAsync(accountrole);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAccountRole(List<AccountRole> accountrole)
        {
            await _context.AccountRoles.AddRangeAsync(accountrole);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAccountRole(AccountRole accountrole)
        {
            _context.AccountRoles.Attach(accountrole);
            return _context.SaveChangesAsync();
        }

        public Task RemoveAccountRole(AccountRole accountrole)
        {
            _context.AccountRoles.Remove(accountrole);
            return _context.SaveChangesAsync();
        }
        public int GetRoleIdByAccountId(int accountId)
        {
            var accountRole = _context.AccountRoles.FirstOrDefault(ar => ar.AccountId == accountId);
            if (accountRole != null)
            {
                return accountRole.RoleId;
            }
            return 0;
        }

    }
}
