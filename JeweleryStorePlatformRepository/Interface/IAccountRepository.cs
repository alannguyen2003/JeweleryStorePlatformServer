using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformDataTransfer.Request.AccountDTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using JeweleryStorePlatformDataTransfer.Request.AccountDTO;

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
        Task<int> GetRoleIdByAccountId(int accountId);
        Task<Account> RegisterNewAccount(SignUpRequest request);
    }
}
