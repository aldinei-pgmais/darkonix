using DarkOnix.Identity.Api.Models;
using DarkOnix.Identity.Api.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DarkOnix.Identity.Api.Services;

public interface IJwtTokenGenerator
{
    Task<UserLoginResponse> GetLoginResponseAsync(string email);
}

public sealed class JwtTokenGenerator(
    UserManager<IdentityUser> userManager,
    IOptions<JwtSettings> jwtSettings
) : IJwtTokenGenerator
{
    private readonly JwtSettings jwtSettings = jwtSettings.Value;

    public async Task<UserLoginResponse> GetLoginResponseAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email)
            ?? throw new InvalidOperationException("Email não encontrado");

        var claims = await GetClaimsAsync(user);
        var accessToken = CreateJwtToken(claims);

        return new UserLoginResponse
        {
            AccessToken = accessToken,
            ExpiresIn = jwtSettings.ExpiresIn.TotalSeconds,
            UsuarioToken = new()
            {
                Id = user.Id,
                Email = user.Email!,
                Claims = claims.Select(i => new UserClaim { Type = i.Type, Value = i.Value })
            }
        };
    }

    private string CreateJwtToken(IList<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

        var token = tokenHandler.CreateToken(new()
        {
            Issuer = jwtSettings.Issuer,
            Audience = jwtSettings.Audience,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow + jwtSettings.ExpiresIn,
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        });

        return tokenHandler.WriteToken(token);
    }

    private async Task<IList<Claim>> GetClaimsAsync(IdentityUser user)
    {
        var claims = await userManager.GetClaimsAsync(user);
        var userRoles = await userManager.GetRolesAsync(user);

        var nowEpochDate = ToUnixEpochDate(DateTime.UtcNow).ToString();

        claims.Add(new(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new(JwtRegisteredClaimNames.Email, user.Email!));
        claims.Add(new(JwtRegisteredClaimNames.Jti, Guid.CreateVersion7().ToString()));
        claims.Add(new(JwtRegisteredClaimNames.Nbf, nowEpochDate));
        claims.Add(new(JwtRegisteredClaimNames.Iat, nowEpochDate, ClaimValueTypes.Integer64));

        foreach (var userRole in userRoles)
        {
            claims.Add(new("role", userRole));
        }

        return claims;
    }

    private static long ToUnixEpochDate(DateTime date)
    {
        return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
