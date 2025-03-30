using DarkOnix.Identity.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DarkOnix.Identity.Api.Configurations;

public static class JwtConfig
{
    public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var appsettingsSection = configuration.GetSection("Jwt");
        services.Configure<JwtSettings>(appsettingsSection);

        var settings = appsettingsSection.Get<JwtSettings>()
            ?? throw new InvalidOperationException("Seção 'Jwt' não configurada");

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = true;
            options.SaveToken = true;
            options.TokenValidationParameters = new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Secret)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = settings.Audience,
                ValidIssuer = settings.Issuer,
            };
        });
    }
}
