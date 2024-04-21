namespace ServerApp.Logic.Stores;

public interface IAuthService {
    Task<IInteractResult<RegistrationResult>> Register(string login, string password);
    Task<IInteractResult<RegistrationResult>> RegisterTelegram(HttpContext httpContext, ulong id, string? firstName = default, string? lastName = default, string? bio = default, string? photoBase64 = default);
    Task<IInteractResult> Refresh(HttpContext httpContext);

}

