using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformService.Interface;

namespace JeweleryStorePlatformAPI.Configuration;

public class Seeding
{
    private readonly IAccountService _accountService;
    private readonly IJeweleryTypeService _jeweleryTypeService;
    private readonly IRoleService _roleService;
    private readonly IDataService _dataService;

    public Seeding(IAccountService accountService, IJeweleryTypeService jeweleryTypeService, 
        IRoleService roleService, IDataService dataService)
    {
        _accountService = accountService;
        _jeweleryTypeService = jeweleryTypeService;
        _roleService = roleService;
        _dataService = dataService;
    }

    public async Task MigrationAsync()
    {
        await _dataService.MigrationAsync();
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
        // Create a GetJeweleryTypesRequest with default or required values
        var request = new GetJeweleryTypesRequest
        {
            Page = 1,
            Size = 10,
            SortBy = "TypeName",
            SortOrder = "asc",
            SearchTerm = null
        };

        // Pass the request to the GetAllJeweleryTypes method
        var paginatedResult = await _jeweleryTypeService.GetAllJeweleryTypes(request);

        // Check if the items list in PaginatedList is empty
        if (paginatedResult.Items.Any())
        {
            return;
        }

        var jeweleryTypes = new List<JeweleryType>()
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

        await _jeweleryTypeService.AddRangeJeweleryTypes(jeweleryTypes);
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