using JeweleryStorePlatformBusinessObject.Account;

namespace JeweleryStorePlatformRepository.Interface;


public interface IAccountRepository
{
    public Task<List<Account>> GetAllAccounts();
    public Task AddNewAccount(Account account);
    public Task AddRangeAccount(List<Account> accounts);
    public Account CheckLogin(string email, string password);
    public int GetRoleIdByAccountId(int accountId);
}