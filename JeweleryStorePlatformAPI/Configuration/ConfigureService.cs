using JeweleryStorePlatformAPI.Configuration.Cloudinary;
using Microsoft.OpenApi.Models;

namespace JeweleryStorePlatformAPI.Configuration;

public static class ConfigureService
{
    public static IServiceCollection AddSeeding(this IServiceCollection services)
    {
        services.AddScoped<Seeding>();
        return services;
    }
    
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
    
    public static IServiceCollection AddSwaggerAuthorization(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo() { Title = "BadmintonRentalPlatform", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });
        return services;
    }
    
    public static IServiceCollection AddCloudinarySetting(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CloudinarySetting>(configuration.GetSection("CloudinarySettings"));
        return services;
    }
}