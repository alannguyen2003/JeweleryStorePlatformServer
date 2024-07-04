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
        return services;
    }

    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        return services;
    }
}