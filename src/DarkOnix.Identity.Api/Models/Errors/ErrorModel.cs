namespace DarkOnix.Identity.Api.Models.Errors;

public sealed class ErrorModel
{
    public ErrorModel(string errorMessage)
    {
        Errors = [errorMessage];
    }

    public ErrorModel(IEnumerable<string> errors)
    {
        Errors = errors;
    }

    public IEnumerable<string> Errors { get; }
}
