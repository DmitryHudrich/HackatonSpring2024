namespace ServerApp.Api.DataTransferObjects.Response;

public record class SuccessLoginResponse(string Token);
public record class UserDataResponse(string Id, ulong TelegramId, string? Name, string Bio, string Login, string PhotoBase64, DateTime RegistrationDate, int Age, double Latitude, double Longtitude, bool IsLinkWeb, bool IsLinkTelegram, uint FriendsCount);
public record class FriendsResponse(List<UserDataResponse> Friends);
