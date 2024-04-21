using NetTopologySuite.Geometries;

namespace ServerApp.Logic.Entities;

public class User {
    public long Id { get; set; }

    public UserInfo UserInfo { get; set; } = null!;
    public string? Login { get; set; }
    public string? Password { get; set; }
    public ulong TelegramId { get; set; } = default;

    public string? PhotoBase64 { get; set; }

    public required DateTime RegistrationDate { get; set; }
    public int? Age { get; set; }

    public Role? Role { get; set; }
    public Point? SearchGeoposition { get; set; }

    public required AuthInfo AuthInfo { get; set; }

    public List<FriendsPair> FriendRecievers { get; set; } = [];
    public List<FriendsPair> FriendSenders { get; set; } = [];

    public RefreshToken? RefreshToken { get; set; }
    public List<Hobby> Hobbies { get; set; } = [];
}

public class AuthInfo {
    public bool Web { get; set; } = false;
    public bool Telegram { get; set; } = false;
}

public class UserInfo {
    public string? Name { get; set; }
    public string? Bio { get; set; }
}
