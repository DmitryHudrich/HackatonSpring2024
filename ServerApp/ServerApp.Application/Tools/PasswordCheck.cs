namespace ServerApp.Application.Tools;

public enum PasswordCheckTroubles {
    TooShort,
    NoDigit,
    NoUppercase,
    NoLowercase,
}

public static class PasswordChecker {
    public static (bool, List<PasswordCheckTroubles>) Check(string password) {
        var troubles = new List<PasswordCheckTroubles>();

        if (password.Length < 8) {
            troubles.Add(PasswordCheckTroubles.TooShort);
        };
        if (!password.Any(char.IsDigit)) {
            troubles.Add(PasswordCheckTroubles.NoDigit);
        }
        if (!password.Any(char.IsUpper)) {
            troubles.Add(PasswordCheckTroubles.NoUppercase);
        }
        if (!password.Any(char.IsLower)) {
            troubles.Add(PasswordCheckTroubles.NoLowercase);
        }

        return
            troubles.Count > 1
                ? ((bool, List<PasswordCheckTroubles>))(false, troubles)
                : ((bool, List<PasswordCheckTroubles>))(true, troubles);
    }
}
