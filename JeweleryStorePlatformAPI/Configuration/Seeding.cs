using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformService.Interface;

namespace JeweleryStorePlatformAPI.Configuration;

public class Seeding
{
    private readonly IAccountService _accountService;
    private readonly IJeweleryTypeService _jeweleryTypeService;
    private readonly IRoleService _roleService;

    public Seeding(IAccountService accountService, IJeweleryTypeService jeweleryTypeService, IRoleService roleService)
    {
        _accountService = accountService;
        _jeweleryTypeService = jeweleryTypeService;
        _roleService = roleService;
    }

    public async Task AccountSeeding()
    {
        var account = await _accountService.GetAllAccounts();
        if (account.Any())
        {
            return;
        }

        var accounts = new List<Account>()
        {
            new Account()
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

    public async Task SeedingJeweleryTypes()
    {
        var jeweleryTypes = await _jeweleryTypeService.GetAllJeweleryType();
        if (jeweleryTypes.Any())
        {
            return;
        }

        jeweleryTypes = new List<JeweleryType>()
        {
            new JeweleryType()
            {
                TypeName = "Necklaces"
            },
            new JeweleryType()
            {
                TypeName = "Rings"
            },
            new JeweleryType()
            {
                TypeName = "Bracelets"
            },
            new JeweleryType()
            {
                TypeName = "Earrings"
            },
            new JeweleryType()
            {
                TypeName = "Wedding-bridals"
            }
        };
        await _jeweleryTypeService.AddRangeJeweleryType(jeweleryTypes);
    }

    public async Task SeedingRole()
    {
        var roles = await _roleService.GetAllRoles();
        if (roles.Any())
        {
            return;
        }

        roles = new List<Role>()
        {
            new Role()
            {
                Name = "Customer"
            },
            new Role()
            {
                Name = "Sales Staff"
            },
            new Role()
            {
                Name = "Delivery Staffs"
            },
            new Role()
            {
                Name = "Manager"
            },
            new Role()
            {
                Name = "Admin"
            }
        };
        await _roleService.AddRangeRoles(roles);
    }
}