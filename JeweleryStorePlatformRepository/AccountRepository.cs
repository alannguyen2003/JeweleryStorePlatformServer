using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;

namespace JeweleryStorePlatformRepository;

public class AccountRepository : IAccountRepository
{
    public async Task<List<AccountEntity>> GetAllAccounts()
    {
        return await AccountDAO.Instance.GetAllAccount();
    }

    public async Task AddNewAccount(AccountEntity account)
    {
        await AccountDAO.Instance.AddNewAccount(account);
    }

    public async Task AddRangeAccount(List<AccountEntity> accounts)
    {
        await AccountDAO.Instance.AddRangeAccount(accounts);
    }
}