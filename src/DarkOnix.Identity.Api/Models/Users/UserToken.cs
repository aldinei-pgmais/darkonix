namespace DarkOnix.Identity.Api.Models.Users;

public sealed class UserToken
{
    public required string Id { get; init; }
    public required string Email { get; init; }
    public required IEnumerable<UserClaim> Claims { get; init; }
}
