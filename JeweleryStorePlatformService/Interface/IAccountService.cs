using JeweleryStorePlatformBusinessObject.Account;

namespace JeweleryStorePlatformService.Interface;

public interface IAccountService
{
    public Task<List<Account>> GetAllAccounts();
    public Task AddNewAccount(Account account);
    public Task AddRangeAccount(List<Account> accounts);
    public string GenerateJwtToken(Account account);
    Account CheckLogin(string email, string password);
    public int GetRoleIdByAccountId(int accountId);
}