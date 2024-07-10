using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformBusinessObject.Diamond;

namespace JeweleryStorePlatformRepository.Interface;

public interface IAccountRepository
{
    public Task<List<AccountEntity>> GetAllAccounts();
    public Task AddNewAccount(AccountEntity account);
    public Task AddRangeAccount(List<AccountEntity> accounts);
}