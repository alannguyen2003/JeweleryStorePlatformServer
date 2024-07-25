using JeweleryStorePlatformAPI.Configuration.Cloudinary.Interface;
using JeweleryStorePlatformRepository;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService;
using JeweleryStorePlatformService.Interface;

namespace JeweleryStorePlatformAPI.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IJeweleryTypeRepository, JeweleryTypeRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IAccountRoleRepository, AccountRoleRepository>();
        services.AddScoped<IDataRepository, DataRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IJeweleryCaseRepository, JeweleryCaseRepository>();
        services.AddTransient<ICityRepository, CityRepository>();
        services.AddTransient<IDistrictRepository, DistrictRepository>();
        services.AddTransient<IAddressRepository, AddressRepository>();
        services.AddTransient<IColorRepository, ColorRepository>();
        services.AddTransient<IMaterialRepository, MaterialRepository>();
        services.AddTransient<ITransactionRepository, TransactionRepository>();
        services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
        services.AddScoped<IJeweleryRepository, JeweleryRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IPromotionRepository, PromotionRepository>();
        services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IJeweleryDesignRepository, JeweleryDesignRepository>();
        services.AddScoped<IJeweleryDesignImageRepository, JeweleryDesignImageRepository>();
        services.AddScoped<IDiamondRepository, DiamondRepository>();
        services.AddScoped<IGIAReportRepository, GIAReportRepository>();
        return services;
    }

    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IJeweleryTypeService, JeweleryTypeService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IDataService, DataService>();
        services.AddScoped<IOrderItemService, OrderItemsService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IJeweleryCaseService, JeweleryCaseService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IAccountRoleService, AccountRoleService>();
        services.AddScoped<IMaterialService, MaterialService>();
        services.AddScoped<IColorService, ColorService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IPromotionService, PromotionService>();
        services.AddScoped<IJeweleryService, JeweleryService>();
        services.AddScoped<IDiamondService, DiamondService>();
        services.AddScoped<IJeweleryDesignService, JeweleryDesignService>();
        services.AddSingleton<HttpClientHelper>();
        services.AddTransient<ApiService>();
        
        services.AddTransient<IProvinceService, ProvinceService>();
        services.AddTransient<IGIAReportService, GIAReportService>();
        return services;
    }
}