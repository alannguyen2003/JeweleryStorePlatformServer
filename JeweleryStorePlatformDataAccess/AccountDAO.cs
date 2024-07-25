using JeweleryStorePlatformBusinessObject.Account;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class AccountDAO
    {
        private readonly AppDbContext _context;
        private static AccountDAO instance;

        public AccountDAO()
        {
            _context = new AppDbContext();
        }

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public async Task<List<Account>> GetAllAccount()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> AddNewAccount(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
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

        public async Task<int> GetRoleIdByAccountId(int accountId)
        {
            var accountRole = await _context.AccountRoles
                .Where(ar => ar.AccountId == accountId)
                .Select(ar => ar.RoleId)
                .FirstOrDefaultAsync();

            return accountRole;
        }
    }
}
