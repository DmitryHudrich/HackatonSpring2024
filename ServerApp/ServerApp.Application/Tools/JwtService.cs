using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ServerApp.Application.Tools.StaticStuff;
using ServerApp.Logic.Entities;

namespace ServerApp.Application.Tools;

public sealed class JwtService(ILogger<JwtService> logger) {
    public RefreshToken GenerateRefreshToken(TimeSpan expire) {
        logger.LogInformation("GenerateRefreshToken: {Expire}", expire);
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return new RefreshToken {
            Token = Convert.ToBase64String(randomNumber),
            Expiration = expire
        };
    }

    public string GenerateJwtToken(User user, HttpContext httpContext, CookieOptions cookieOptions) {
        logger.LogInformation("GenerateJwtToken: {User}", user);

        var claims = new List<Claim>();
        SetClaims(user, claims);

        var jwt =
            new JwtSecurityToken(
                issuer: ApplicationOptions.JwtOptions.Issuer,
                audience: ApplicationOptions.JwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(ApplicationOptions.JwtOptions.JwtExpirationTime),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key")),
                    SecurityAlgorithms.HmacSha256
            )
        );

        var cookie = httpContext.Response.Cookies;

        var refresh = GenerateRefreshToken(ApplicationOptions.RefreshTokenExpiration);
        if (user.Login != null) {
            cookie.Append("X-Username", user.Login, cookieOptions);
        }

        cookie.Append("X-Guid", user.Id.ToString());
        cookie.Append("X-Access", new JwtSecurityTokenHandler().WriteToken(jwt), cookieOptions);
        cookie.Append("X-Refresh", refresh.Token, cookieOptions);

        // TODO: add refresh to db

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private static void SetClaims(User user, List<Claim> claims) {
        if (user.AuthInfo.Web) {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Login!));
        }
        if (user.AuthInfo.Telegram) {
            claims.Add(new Claim(ClaimTypes.Sid, user.TelegramId.ToString()));
        }

        claims.Add(new Claim(ClaimTypes.SerialNumber, user.Id.ToString()));
    }
}
