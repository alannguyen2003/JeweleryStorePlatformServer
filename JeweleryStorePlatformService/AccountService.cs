using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;

namespace JeweleryStorePlatformService;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    public async Task<List<AccountEntity>> GetAllAccounts()
    {
        return await _accountRepository.GetAllAccounts();
    }

    public async Task AddNewAccount(AccountEntity account)
    {
        await _accountRepository.AddNewAccount(account);
    }

    public async Task AddRangeAccount(List<AccountEntity> accounts)
    {
        await _accountRepository.AddRangeAccount(accounts);
    }
}