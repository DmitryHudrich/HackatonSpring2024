namespace ServerApp.Logic.Stores;

public interface IAuthService<TResultInfo> {
    Task<IInteractResult<TResultInfo>> Register(string login, string password);
    Task<IInteractResult<TResultInfo>> RegisterTelegram(HttpContext httpContext, ulong id, string? firstName = default, string? lastName = default, string? bio = default, string? photoBase64 = default);
}

