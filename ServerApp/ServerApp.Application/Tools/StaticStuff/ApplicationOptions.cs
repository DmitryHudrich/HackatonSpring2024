namespace ServerApp.Application.Tools.StaticStuff;

internal class ApplicationOptions {
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

internal class JwtOptions {
    public required string Audience;
    public required string Issuer;
    public required double JwtExpirationTime;
}
