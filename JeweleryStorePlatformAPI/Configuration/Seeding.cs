using Azure.Core;
using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformBusinessObject.Constant;
using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformBusinessObject.Transaction;
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
    private readonly IJeweleryCaseService _jeweleryCaseService;
    private readonly IColorService _colorService;
    private readonly IMaterialService _materialService;
    private readonly IPaymentMethodRepository _paymentMethodRepository;

    public Seeding(IAccountService accountService, IJeweleryTypeService jeweleryTypeService, 
        IRoleService roleService, IDataService dataService, IDiamondService diamondService, IGIAReportService gIAReportService, IProvinceService provinceService, IJeweleryCaseService jeweleryCaseService,
        IColorService colorService, IMaterialService materialService, IPaymentMethodRepository paymentMethodRepository)
    {
        _accountService = accountService;
        _jeweleryTypeService = jeweleryTypeService;
        _roleService = roleService;
        _dataService = dataService;
        _diamondService = diamondService;
        _gIAReportService = gIAReportService;
        _provinceService = provinceService;
        _jeweleryCaseService = jeweleryCaseService;
        _colorService = colorService;
        _materialService = materialService;
        _paymentMethodRepository = paymentMethodRepository;
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
            },
            new Account()
            {
                Email = "honhungoc@gmail.com",
                FirstName = "Ho Nhu",
                MiddleName = "",
                ProfileImage = "",
                LastName = "Ngoc",
                EmailConfirmed = true,
                PhoneNumber = "0123456789",
                Points = 0,
                DateOfBirth = DateTime.Now,
                Password = "12345"
            },
            new Account()
            {
                Email = "minhnguyet@gmail.com",
                FirstName = "Minh",
                MiddleName = "",
                ProfileImage = "",
                LastName = "Nguyet",
                EmailConfirmed = true,
                PhoneNumber = "012341231",
                Points = 0,
                DateOfBirth = DateTime.Now,
                Password = "12345"
            },
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
            },
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
            },
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
            },
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
            },
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
            },
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
            Price = 10382000,
            CutType = CutTypeConstant.EXCELLENT,
            CaratType = CaratTypeConstant.CT3P6,
            ColorType = ColorTypeConstant.D,
            ClarityType = ClarityTypeConstant.IF,
            DiamondOrigin = DiamondOriginConstant.NATURAL,
            PreviewImage = "https://product.hstatic.net/1000381168/product/upload_17785375e47c4a1089ba2cbf703f7e75_1024x1024.jpg",
            IsMainDiamond = true 
        },
        new Diamond
        {
            Price = 13643000,
            CutType = CutTypeConstant.VERY_GOOD,
            CaratType = CaratTypeConstant.CT4P5,
            ColorType = ColorTypeConstant.F,
            ClarityType = ClarityTypeConstant.VVS1,
            DiamondOrigin = DiamondOriginConstant.NATURAL,
            PreviewImage = "https://product.hstatic.net/1000381168/product/upload_17785375e47c4a1089ba2cbf703f7e75_1024x1024.jpg",
            IsMainDiamond = false 
        },
        new Diamond
        {
            Price = 12433000,
            CutType = CutTypeConstant.VERY_GOOD,
            CaratType = CaratTypeConstant.CT4P1,
            ColorType = ColorTypeConstant.F,
            ClarityType = ClarityTypeConstant.VS1,
            DiamondOrigin = DiamondOriginConstant.NATURAL,
            PreviewImage = "https://product.hstatic.net/1000381168/product/upload_17785375e47c4a1089ba2cbf703f7e75_1024x1024.jpg",
            IsMainDiamond = false
        },
        new Diamond
        {
            Price = 9750000,
            CutType = CutTypeConstant.EXCELLENT,
            CaratType = CaratTypeConstant.CT6P,
            ColorType = ColorTypeConstant.G,
            ClarityType = ClarityTypeConstant.IF,
            DiamondOrigin = DiamondOriginConstant.NATURAL,
            PreviewImage = "https://product.hstatic.net/1000381168/product/upload_17785375e47c4a1089ba2cbf703f7e75_1024x1024.jpg",
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
        new GIAReport { ReportNumber = "2141438172", ReportUrl = "http://example.com/report1", DiamondId = addedDiamonds.Items[0].Id },
        new GIAReport { ReportNumber = "2141438173", ReportUrl = "http://example.com/report2", DiamondId = addedDiamonds.Items[1].Id },
        new GIAReport { ReportNumber = "2141438174", ReportUrl = "http://example.com/report3", DiamondId = addedDiamonds.Items[2].Id },
        new GIAReport { ReportNumber = "2141438175", ReportUrl = "http://example.com/report4", DiamondId = addedDiamonds.Items[3].Id }
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
        await _provinceService.FetchAndStoreDataAsync();
    }
    public async Task SeedingColor()
    {
        var colors = await _colorService.GetAllColors();
        if (colors.Any())
        {
            return;
        }

        colors = new List<Color>()
    {
        new Color()
        {
            ColorDescription = "Red"
        },
        new Color()
        {
            ColorDescription = "Blue"
        },
        new Color()
        {
            ColorDescription = "Green"
        },
        new Color()
        {
            ColorDescription = "Yellow"
        },
        new Color()
        {
            ColorDescription = "Black"
        }
    };
        await _colorService.AddRange(colors);
    }
    public async Task SeedingMaterial()
    {
        var materials = await _materialService.GetAllMaterials();
        if (materials.Any())
        {
            return;
        }

        materials = new List<Material>()
    {
        new Material()
        {
            MaterialDescription = "Gold"
        },
        new Material()
        {
            MaterialDescription = "Silver"
        },
        new Material()
        {
            MaterialDescription = "Platinum"
        },
        new Material()
        {
            MaterialDescription = "Palladium"
        },
        new Material()
        {
            MaterialDescription = "Titanium"
        }
    };
        await _materialService.AddRange(materials);
    }
    public async Task SeedingJeweleryCases()
    {
        var jeweleryCases = await _jeweleryCaseService.GetAll();
        if (jeweleryCases.Any())
        {
            return;
        }
        var colors = await _colorService.GetAllColors();
        var materials = await _materialService.GetAllMaterials();
        if (!colors.Any() || !materials.Any())
        {
            throw new InvalidOperationException("Màu sắc hoặc vật liệu không có trong cơ sở dữ liệu.");
        }
        var colorIds = colors.Select(c => c.Id).ToList();
        var materialIds = materials.Select(m => m.Id).ToList();
        var jeweleryCasesToAdd = new List<JeweleryCase>()
        {
            new JeweleryCase()
            {
                CaseName = "Luxury Gold Case",
                ColorId = colorIds[0],
                MaterialId = materialIds[0]
            },
            new JeweleryCase()
            {
                CaseName = "Elegant Silver Case",
                ColorId = colorIds[1],
                MaterialId = materialIds[1]
            },
            new JeweleryCase()
            {
                CaseName = "Classic Wooden Case",
                ColorId = colorIds[2],
                MaterialId = materialIds[2]
            },
            new JeweleryCase()
            {
                CaseName = "Modern Glass Case",
                ColorId = colorIds[3],
                MaterialId = materialIds[3]
            },
            new JeweleryCase()
            {
                CaseName = "Vintage Leather Case",
                ColorId = colorIds[4],
                MaterialId = materialIds[4]
            }
        };

        await _jeweleryCaseService.AddRange(jeweleryCasesToAdd);
    }
    public async Task SeedingPaymentMethod()
    {
        var paymentmedthod = await _paymentMethodRepository.GetAllPaymentMethods();
        if (paymentmedthod.Any())
        {
            return;
        }

        paymentmedthod = new List<PaymentMethod>()
    {
        new PaymentMethod()
        {
            PaymentMethodName = "PayOs"
        },
        
    };
        await _paymentMethodRepository.AddRange(paymentmedthod);
    }

}