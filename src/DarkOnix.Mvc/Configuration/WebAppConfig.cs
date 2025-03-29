namespace DarkOnix.Mvc.Configuration;

public static class WebAppConfig
{
    public static void AddMvcConfiguration(this IServiceCollection services)
    {
        services.AddControllersWithViews();
    }

    public static void UseMvcConfiguration(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.MapStaticAssets();

        app.UseIdentityConfiguration();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();
    }
}
