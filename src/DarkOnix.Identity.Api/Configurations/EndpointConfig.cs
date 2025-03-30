using DarkOnix.Identity.Api.Endpoints.Identity;

namespace DarkOnix.Identity.Api.Configurations;

public static class EndpointConfig
{
    public static void UseEndpointConfiguration(this WebApplication app)
    {
        app.MapRegisterEndpoint();
        app.MapLoginEndpoint();
    }
}
