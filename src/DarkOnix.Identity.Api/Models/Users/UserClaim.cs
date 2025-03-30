namespace DarkOnix.Identity.Api.Models.Users;

public sealed class UserClaim
{
    public required string Type { get; init; }
    public required string Value { get; init; }
}