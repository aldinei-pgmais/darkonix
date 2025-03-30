using Microsoft.OpenApi.Models;

namespace DarkOnix.Identidade.Api.Configurations;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "DarkOnix.Identidade.Api",
                Description = "Esta API é um trabalho acadêmico - MBA DevExpert",
                Contact = new()
                {
                    Name = "Aldinei Sampaio",
                    Email = "aldinei.sampaio@pgmais.com.br",
                    Url = new Uri("https://github.com/aldinei-pgmais")
                },
                License = new() { Name = "MIT", Url = new Uri("https://mit-license.org/") },
                TermsOfService = new Uri("https://github.com/aldinei-pgmais/darkonix/TERMOSOFSERVICE.md")
            });
        });
    }

    public static void UseSwaggerConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
