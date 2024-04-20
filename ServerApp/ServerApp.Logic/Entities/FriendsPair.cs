namespace ServerApp.Logic.Entities;

public class FriendsPair {
    public long Id { get; set; }

    public required User Sender { get; set; }
    public required User Reciever { get; set; }
}

