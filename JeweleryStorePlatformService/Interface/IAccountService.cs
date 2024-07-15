using JeweleryStorePlatformBusinessObject.Account;

namespace JeweleryStorePlatformService.Interface
{
    public interface IAccountService
    {
        Task<List<Account>> GetAllAccounts();
        Task AddNewAccount(Account account);
        Task AddRangeAccount(List<Account> accounts);
        string GenerateJwtToken(Account account);
        Account CheckLogin(string email, string password);
        Task<Account> Register(Account account);
        Task<Account> UpdateAccount(Account account);
        Task<bool> DeleteAccount(int accountId);
        Task<Account> GetAccountById(int accountId);
    }
}
