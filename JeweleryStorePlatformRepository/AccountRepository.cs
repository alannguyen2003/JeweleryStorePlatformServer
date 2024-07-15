using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task AddNewAccount(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAccount(List<Account> accounts)
        {
            await _context.Accounts.AddRangeAsync(accounts);
            await _context.SaveChangesAsync();
        }

        public Account CheckLogin(string email, string password)
        {
            return _context.Accounts.FirstOrDefault(l => l.Email == email && l.Password == password);
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<bool> DeleteAccount(int accountId)
        {
            var account = await _context.Accounts.FindAsync(accountId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Account> GetAccountById(int accountId)
        {
            return await _context.Accounts.FindAsync(accountId);
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
