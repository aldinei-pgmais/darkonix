using DarkOnix.Identidade.Api.Endpoints.Identidade;

namespace DarkOnix.Identidade.Api.Configurations;

public static class EndpointConfig
{
    public static void UseEndpointConfiguration(this WebApplication app)
    {
        app.MapRegistrarEndpoint();
        app.MapLoginEndpoint();
    }
}
