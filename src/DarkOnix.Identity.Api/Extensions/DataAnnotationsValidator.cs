using DarkOnix.Identity.Api.Models.Errors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DarkOnix.Identity.Api.Extensions;

public static class DataAnnotationsValidator
{
    private static bool TryValidate(object model, out List<ValidationResult> results)
    {
        results = [];
        var context = new ValidationContext(model);
        return Validator.TryValidateObject(model, context, results, true);
    }

    public static RouteHandlerBuilder Validate<T>(this RouteHandlerBuilder builder)
    {
        builder.AddEndpointFilter(async (invocationContext, next) =>
        {
            var argument = invocationContext.Arguments.OfType<T>().FirstOrDefault();
            if (argument is null)
                return await next(invocationContext);

            if (TryValidate(argument, out var results))
                return await next(invocationContext);

            var errorList = results
                .Where(i => !string.IsNullOrEmpty(i.ErrorMessage))
                .Select(i => i.ErrorMessage!);

            var q = from r in results
                    from m in r.MemberNames
                    group r.ErrorMessage by m into g
                    select g;

            var response = new ValidationProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Ocorreram um ou mais erros de validação.",
                Errors = q.ToDictionary(i => i.Key, i => i.ToArray())
            };

            return Results.BadRequest(response);
        });

        return builder;
    }
}