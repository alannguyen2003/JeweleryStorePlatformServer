using JeweleryStorePlatformBusinessObject.Account;

namespace JeweleryStorePlatformService.Interface;

public interface IAccountService
{
    public Task<List<AccountEntity>> GetAllAccounts();
    public Task AddNewAccount(AccountEntity account);
    public Task AddRangeAccount(List<AccountEntity> accounts);
    
}