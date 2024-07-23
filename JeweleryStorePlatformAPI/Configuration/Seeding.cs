using Azure.Core;
using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService;
using JeweleryStorePlatformService.Interface;
using Octopus.Server.MessageContracts.Base;
using Service.Models.Payload.Requests.Member;

namespace JeweleryStorePlatformAPI.Configuration;

public class Seeding
{
    private readonly IAccountService _accountService;
    private readonly IJeweleryTypeService _jeweleryTypeService;
    private readonly IRoleService _roleService;
    private readonly IDataService _dataService;
    private readonly IDiamondService _diamondService;
    private readonly IGIAReportService _gIAReportService;
    private readonly IProvinceService _provinceService;

    public Seeding(IAccountService accountService, IJeweleryTypeService jeweleryTypeService, 
        IRoleService roleService, IDataService dataService, IDiamondService diamondService, IGIAReportService gIAReportService, IProvinceService provinceService)
    {
        _accountService = accountService;
        _jeweleryTypeService = jeweleryTypeService;
        _roleService = roleService;
        _dataService = dataService;
        _diamondService = diamondService;
        _gIAReportService = gIAReportService;
        _provinceService = provinceService;
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
    public async Task SeedingDiamond()
    {
        var request = new GetDiamondsRequest
        {
            Page = 1, 
            Size = 1, 
            SearchTerm = null, 
            SortBy = "Id", 
            SortOrder = "asc" 
        };
        var diamondsResponse = await _diamondService.GetAllDiamonds(request);
        if (diamondsResponse.Items.Any())
        {
            return;
        }
        var sampleDiamonds = new List<Diamond>
    {
        new Diamond
        {
            Price = 1000,
            CutType = "Excellent",
            CaratType = "1.0",
            ColorType = "D",
            ClarityType = "IF",
            DiamondOrigin = "South Africa",
            PreviewImage = "image1.jpg",
            IsMainDiamond = true 
        },
        new Diamond
        {
            Price = 750,
            CutType = "Very Good",
            CaratType = "0.75",
            ColorType = "E",
            ClarityType = "VVS1",
            DiamondOrigin = "Brazil",
            PreviewImage = "image2.jpg",
            IsMainDiamond = false 
        },
        new Diamond
        {
            Price = 500,
            CutType = "Good",
            CaratType = "0.50",
            ColorType = "F",
            ClarityType = "VS1",
            DiamondOrigin = "Russia",
            PreviewImage = "image3.jpg",
            IsMainDiamond = false
        },
        new Diamond
        {
            Price = 250,
            CutType = "Fair",
            CaratType = "0.25",
            ColorType = "G",
            ClarityType = "SI1",
            DiamondOrigin = "India",
            PreviewImage = "image4.jpg",
            IsMainDiamond = false
        }
    };

         await _diamondService.AddRangeDiamonds(sampleDiamonds);

        var addedDiamonds = await _diamondService.GetAllDiamonds(new GetDiamondsRequest
        {
            Page = 1,
            Size = sampleDiamonds.Count,
            SearchTerm = null,
            SortBy = "Id",
            SortOrder = "asc"
        });
        var giaReports = new List<GIAReport>
    {
        new GIAReport { ReportNumber = "R12345", ReportUrl = "http://example.com/report1", DiamondId = addedDiamonds.Items[0].Id },
        new GIAReport { ReportNumber = "R12346", ReportUrl = "http://example.com/report2", DiamondId = addedDiamonds.Items[1].Id },
        new GIAReport { ReportNumber = "R12347", ReportUrl = "http://example.com/report3", DiamondId = addedDiamonds.Items[2].Id },
        new GIAReport { ReportNumber = "R12348", ReportUrl = "http://example.com/report4", DiamondId = addedDiamonds.Items[3].Id }
    };

        await _gIAReportService.AddRangeGIAReports(giaReports);
    }
    public async Task SeedingAddress()
    {
        var city = await _provinceService.GetAllCities();
        if (city.Any())
        {
            return;
        }
        var district = await _provinceService.GetAllDistricts();
        if (district.Any())
        {
            return;
        }
        var address = await _provinceService.GetAllAddresses();
        if (address.Any())
        {
            return;
        }
        await _provinceService.FetchAndStoreDataAsync();
    }

    }