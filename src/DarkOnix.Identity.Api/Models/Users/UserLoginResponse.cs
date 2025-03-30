namespace DarkOnix.Identity.Api.Models.Users;

public sealed class UserLoginResponse
{
    public required string AccessToken { get; init; }
    public required double ExpiresIn { get; init; }
    public required UserToken UsuarioToken { get; init; }
}
