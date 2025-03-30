using System.ComponentModel.DataAnnotations;

namespace DarkOnix.Identidade.Api.Extensions;

public static class DataValidator
{
    private static (List<ValidationResult> Results, bool IsValid) DataAnnotationsValidate(this object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model);

        var isValid = Validator.TryValidateObject(model, context, results, true);

        return (results, isValid);
    }

    public static RouteHandlerBuilder Validate<T>(this RouteHandlerBuilder builder, bool firstErrorOnly = true)
    {
        builder.AddEndpointFilter(async (invocationContext, next) =>
        {
            var argument = invocationContext.Arguments.OfType<T>().FirstOrDefault();
            if (argument is not null)
            {
                var response = argument.DataAnnotationsValidate();

                if (!response.IsValid)
                {
                    string errorMessage = firstErrorOnly ?
                                            response.Results.First().ErrorMessage! :
                                            string.Join("|", response.Results.Select(x => x.ErrorMessage));

                    return Results.Problem(errorMessage, statusCode: 400);
                }
            }

            return await next(invocationContext);
        });

        return builder;
    }
}