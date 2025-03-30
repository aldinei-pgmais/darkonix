using DarkOnix.Identity.Api.Extensions;
using DarkOnix.Identity.Api.Models.Errors;
using DarkOnix.Identity.Api.Models.Users;
using DarkOnix.Identity.Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DarkOnix.Identity.Api.Endpoints.Identity;

public static class RegisterEndpoint
{
    public static IEndpointRouteBuilder MapRegisterEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("/api/identity/register", HandleAsync)
            .WithTags("Identity")
            .WithSummary("Register")
            .WithDescription("Efetua a criação de um usuário")
            .Produces<UserLoginResponse>(StatusCodes.Status200OK)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .Validate<UserRegister>();
        return endpointRouteBuilder;
    }

    private static async Task<IResult> HandleAsync(
        UserRegister request,
        UserManager<IdentityUser> userManager,
        IJwtTokenGenerator jwtTokenGenerator
    )
    {
        var user = new IdentityUser
        {
            UserName = request.Email,
            Email = request.Email,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.ToDictionary(i => i.Code, i => new string[] { i.Description });
            return EndpointHelper.ValidationResult(errors);
        }

        var response = await jwtTokenGenerator.GetLoginResponseAsync(request.Email);
        return Results.Ok(response);
    }
}
