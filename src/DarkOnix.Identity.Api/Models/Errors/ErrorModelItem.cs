namespace DarkOnix.Identity.Api.Models.Errors;

public sealed class ErrorModelItem
{
    public required string Code { get; init; }
    public required string Description { get; init; }
}
