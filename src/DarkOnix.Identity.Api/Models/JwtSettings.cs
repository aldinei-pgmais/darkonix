namespace DarkOnix.Identity.Api.Models;

public sealed class JwtSettings
{
    public required string Secret { get; init; }
    public required TimeSpan ExpiresIn { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
}
