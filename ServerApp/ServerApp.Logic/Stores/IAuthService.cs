namespace ServerApp.Logic.Stores;

public interface IAuthService {
    Task<IInteractResult<string>> Register(string login, string password, string? firstName = default, string? lastName = default, string? bio = default, string? photoBase64 = default);
    Task<IInteractResult<string>> RegisterTelegram(HttpContext httpContext, ulong id, string? firstName = default, string? lastName = default, string? bio = default, string? photoBase64 = default);
    Task<IInteractResult<string>> Refresh(HttpContext httpContext);

}

