using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformBusinessObject.Diamond;

namespace JeweleryStorePlatformRepository.Interface;

public interface IAccountRepository
{
    public Task<List<Account>> GetAllAccounts();
    public Task AddNewAccount(Account account);
    public Task AddRangeAccount(List<Account> accounts);
    public string GenerateJwtToken();
}