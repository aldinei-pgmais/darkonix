using DarkOnix.Identidade.Api.Extensions;
using DarkOnix.Identidade.Api.Models.Usuarios;
using Microsoft.AspNetCore.Identity;

namespace DarkOnix.Identidade.Api.Endpoints.Identidade;

public static class RegistrarEndpoint
{
    public static IEndpointRouteBuilder MapRegistrarEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("/api/identidade/registrar()", HandleAsync)
            .WithTags("Auth")
            .WithSummary("Registrar")
            .WithDescription("Efetua a criação de um usuário")
            .Validate<UsuarioLogin>(false);
        return endpointRouteBuilder;
    }

    private static async Task<IResult> HandleAsync(
        UsuarioRegistro usuarioRegistro,
        UserManager<IdentityUser> userManager
    )
    {
        var user = new IdentityUser
        {
            UserName = usuarioRegistro.Email,
            Email = usuarioRegistro.Email,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, usuarioRegistro.Senha);
        if (result.Succeeded)
            return Results.Ok();

        return Results.BadRequest(result);
    }
}
