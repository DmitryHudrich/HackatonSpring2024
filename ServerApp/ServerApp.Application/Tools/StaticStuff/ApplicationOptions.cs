using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ServerApp.Application.Tools.StaticStuff;

public class ApplicationOptions {
    public static readonly CookieOptions SecureCookieOptions = new CookieOptions {
        HttpOnly = true,
        Secure = true
    };

    public static readonly JwtOptions JwtOptions = new JwtOptions {
        Audience = "BERBEROVKA_SHASHLIKI",
        Issuer = "BERBEROVKA_SHASHLIKI_ISSUER",
        JwtExpirationTime = 30,
    };

    public static readonly TimeSpan RefreshTokenExpiration = TimeSpan.FromDays(180);
}

public class JwtOptions {
    public required string Audience;
    public required string Issuer;
    public required double JwtExpirationTime;
    const string DONT_STEAL_THIS_PLEASE_BRO = "adnag;;oi3u0-u[fjs;aofj;ehnfpqhweohfksldj";
    public SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(DONT_STEAL_THIS_PLEASE_BRO));
}
