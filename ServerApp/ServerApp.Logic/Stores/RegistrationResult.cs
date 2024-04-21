namespace ServerApp.Logic.Stores;

public record class RegistrationResult(bool Success, List<PasswordCheckTroubles> Issues, string? Jwt = default);

public enum PasswordCheckTroubles {
    TooShort,
    NoDigit,
    NoUppercase,
    NoLowercase,
}
