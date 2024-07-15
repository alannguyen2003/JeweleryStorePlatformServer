using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;

namespace JeweleryStorePlatformRepository;

public class AccountRepository : IAccountRepository
{
    public async Task<List<Account>> GetAllAccounts()
    {
        return await AccountDAO.Instance.GetAllAccount();
    }

    public async Task AddNewAccount(Account account)
    {
        await AccountDAO.Instance.AddNewAccount(account);
    }

    public async Task AddRangeAccount(List<Account> accounts)
    {
        await AccountDAO.Instance.AddRangeAccount(accounts);
    }

    public Account CheckLogin(string email, string password)
    {
        return AccountDAO.Instance.CheckLogin(email, password);
    }
    public int GetRoleIdByAccountId(int accountId)
    {
        return AccountDAO.Instance.GetRoleIdByAccountId((int)accountId);
    }
}