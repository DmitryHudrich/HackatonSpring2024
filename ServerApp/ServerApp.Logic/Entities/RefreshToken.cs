namespace ServerApp.Logic.Entities;

public class RefreshToken {
    public required string Token { get; set; }
    public required TimeSpan Expiration { get; set; }
}
