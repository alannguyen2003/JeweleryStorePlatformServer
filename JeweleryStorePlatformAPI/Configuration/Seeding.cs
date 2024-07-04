using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformService.Interface;

namespace JeweleryStorePlatformAPI.Configuration;

public class Seeding
{
    private readonly IAccountService _accountService;

    public Seeding(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task AccountSeeding()
    {
        var account = await _accountService.GetAllAccounts();
        if (account.Any())
        {
            return;
        }

        var accounts = new List<AccountEntity>()
        {
            new AccountEntity()
            {
                Email = "nguyenho30112003@gmail.com",
                FirstName = "Ho Duong",
                MiddleName = "",
                ProfileImage = "",
                LastName = "Trung Nguyen",
                EmailConfirmed = true,
                PhoneNumber = "0847919292",
                Points = 0,
                DateOfBirth = DateTime.Now,
                Password = "12345"
            }
        };
        await _accountService.AddRangeAccount(accounts);
    }
}