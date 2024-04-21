namespace ServerApp.Api.DataTransferObjects.Request;

internal record class RegistrationRequest(string Login, string Password, string? FirstName = default, string? LastName = default, string? Bio = default, string? PhotoBase64 = default);
internal record class LoginRequest(string Login, string Password);
internal record class TelegramRegistrationRequest(ulong TelegramId, string FirstName = "", string LastName = "", string Bio = "", string PhotoBase64 = "");
internal record class TelegramSyncRequest(long UserId, ulong TelegramId);
internal record class NewHobbyRequest(string Name);
internal record class NewActivityTypeRequest(string Name);
