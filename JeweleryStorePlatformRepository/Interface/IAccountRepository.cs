using JeweleryStorePlatformBusinessObject.Account;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAccounts();
        Task AddNewAccount(Account account);
        Task AddRangeAccount(List<Account> accounts);
        Account CheckLogin(string email, string password);
        Task<Account> UpdateAccount(Account account);
        Task<bool> DeleteAccount(int accountId);
        Task<Account> GetAccountById(int accountId);
        public int GetRoleIdByAccountId(int accountId);
    }
}
