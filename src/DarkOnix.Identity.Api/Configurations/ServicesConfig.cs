using DarkOnix.Identity.Api.Services;

namespace DarkOnix.Identity.Api.Configurations;

public static class ServicesConfig
{
    public static void AddServicesConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
    }
}
