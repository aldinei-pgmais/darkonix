using Microsoft.AspNetCore.Mvc;

namespace DarkOnix.Identity.Api.Endpoints;

public static class EndpointHelper
{
    public static IResult ValidationResult(IDictionary<string, string[]> errors)
    {
        return Results.BadRequest(new ValidationProblemDetails
        {
            Title = "Ocorreram um ou mais erros de validação.",
            Errors = errors
        });
    }

    public static IResult ValidationResult(string errorCode, string errorMessage)
    {
        return Results.BadRequest(new ValidationProblemDetails
        {
            Title = "Ocorreram um ou mais erros de validação.",
            Errors = new Dictionary<string, string[]> { { errorCode, [errorMessage] } }
        });
    }
}
