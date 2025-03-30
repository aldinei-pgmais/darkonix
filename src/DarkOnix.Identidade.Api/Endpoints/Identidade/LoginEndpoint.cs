using DarkOnix.Identidade.Api.Extensions;
using DarkOnix.Identidade.Api.Models.Usuarios;
using Microsoft.AspNetCore.Identity;

namespace DarkOnix.Identidade.Api.Endpoints.Identidade;

public static class LoginEndpoint
{
    public static IEndpointRouteBuilder MapLoginEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("/api/identidade/login()", HandleAsync)
            .WithTags("Auth")
            .WithSummary("Login")
            .WithDescription("Efetua o login de um usuário")
            .Validate<UsuarioLogin>(false);
        return endpointRouteBuilder;
    }

    private static async Task<IResult> HandleAsync(
        UsuarioLogin usuarioLogin,
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager
    )
    {
        var result = await signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);
        if (result.Succeeded)
            return Results.Ok();

        return Results.BadRequest();
    }

}
