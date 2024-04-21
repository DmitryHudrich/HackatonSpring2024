namespace ServerApp.Api.DataTransferObjects.Request;

internal record class RegistrationRequest(string Login, string Password, string Name = "", string Bio = "");
internal record class LoginRequest(string Login, string? Password);
internal record class TelegramRegistrationRequest(ulong TelegramId, string FirstName = "", string LastName = "", string Bio = "", string PhotoBase64 = "");
internal record class TelegramSyncRequest(long UserId, ulong TelegramId);
