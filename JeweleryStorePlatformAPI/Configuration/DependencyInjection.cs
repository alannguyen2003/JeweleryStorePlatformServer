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
        return services;
    }

    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IJeweleryTypeService, JeweleryTypeService>();
        services.AddScoped<IRoleService, RoleService>();
        return services;
    }
}