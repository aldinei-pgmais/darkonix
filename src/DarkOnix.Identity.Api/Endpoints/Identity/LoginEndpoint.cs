using DarkOnix.Identity.Api.Extensions;
using DarkOnix.Identity.Api.Models.Users;
using DarkOnix.Identity.Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DarkOnix.Identity.Api.Endpoints.Identity;

public static class LoginEndpoint
{
    public static IEndpointRouteBuilder MapLoginEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("/api/identity/login", HandleAsync)
            .WithTags("Identity")
            .WithSummary("Login")
            .WithDescription("Efetua o login de um usuário")
            .Produces<UserLoginResponse>(StatusCodes.Status200OK)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .Validate<UserLogin>();
        return endpointRouteBuilder;
    }

    private static async Task<IResult> HandleAsync(
        UserLogin request,
        SignInManager<IdentityUser> signInManager,
        IJwtTokenGenerator jwtTokenGenerator
    )
    {
        var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, false, true);

        if (result.Succeeded)
        {
            var response = await jwtTokenGenerator.GetLoginResponseAsync(request.Email);
            return Results.Ok(response);
        }

        if (result.IsLockedOut)
            return EndpointHelper.ValidationResult("LockedOut", "Usuário temporariamente bloqueado");

        if (result.IsNotAllowed)
            return EndpointHelper.ValidationResult("NotAllowed", "Sem permissão de acesso");

        return EndpointHelper.ValidationResult("LoginFailure", "Usuário ou senha inválida");
    }
}
