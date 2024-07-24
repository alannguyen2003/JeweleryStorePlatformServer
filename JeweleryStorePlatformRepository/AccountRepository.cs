using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class AccountRepository : IAccountRepository
    {

        public async Task<List<Account>> GetAllAccounts()
        {
            return await AccountDAO.Instance.GetAllAccount();
        }

        public async Task AddNewAccount(Account account)
        {
            await AccountDAO.Instance.AddNewAccount(account);
        }

        public async Task AddRangeAccount(List<Account> accounts)
        {
            await AccountDAO.Instance.AddRangeAccount(accounts);
        }

        public Account CheckLogin(string email, string password)
        {
            return AccountDAO.Instance.CheckLogin(email, password);
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            return await AccountDAO.Instance.UpdateAccount(account);
        }

        public async Task<bool> DeleteAccount(int accountId)
        {
            return await AccountDAO.Instance.DeleteAccount(accountId);
        }

        public async Task<Account> GetAccountById(int accountId)
        {
            return await AccountDAO.Instance.GetAccountById(accountId);
        }

        public async Task<int> GetRoleIdByAccountId(int accountId)
        {
            return await AccountDAO.Instance.GetRoleIdByAccountId(accountId);
        }
    }
}
