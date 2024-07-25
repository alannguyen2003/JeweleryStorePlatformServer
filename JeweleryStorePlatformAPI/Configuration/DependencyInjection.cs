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
        return services;
    }
}