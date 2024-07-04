using JeweleryStorePlatformBusinessObject.Account;

namespace JeweleryStorePlatformRepository.Interface;

public interface IAccountRepository
{
    public Task<List<AccountEntity>> GetAllAccounts();
    public Task AddNewAccount(AccountEntity account);
    public Task AddRangeAccount(List<AccountEntity> accounts);
}