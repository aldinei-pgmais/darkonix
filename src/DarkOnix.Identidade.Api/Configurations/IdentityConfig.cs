using DarkOnix.Identidade.Api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DarkOnix.Identidade.Api.Configurations;

public static class IdentityConfig
{
    public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }

    public static void UseIdentityConfiguration(this WebApplication app)
    {
        app.UseAuthorization();
        app.UseAuthentication();
    }
}
