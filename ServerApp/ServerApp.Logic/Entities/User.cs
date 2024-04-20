using NetTopologySuite.Geometries;

namespace ServerApp.Logic.Entities;

public class User {
    public long Id { get; set; }

    public required string Name { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }

    public required string PhotoBase64 { get; set; }

    public required DateTime RegistrationDate { get; set; }
    public required int Age { get; set; }

    public required Role Role { get; set; }
    public Point? SearchGeoposition { get; set; }

    public List<FriendsPair> FriendRecievers { get; set; } = [];
    public List<FriendsPair> FriendSenders { get; set; } = [];

    public List<Hobby> Hobbies { get; set; } = [];
}

public class Hobby {
    public long Id { get; set; }
    public required string Name { get; set; }

    public List<User> HobbyOwners { get; set; } = [];
    public List<ActivityType> LinkedActivityTypes { get; set; } = [];
}

public class FriendsPair {
    public long Id { get; set; }

    public required User Sender { get; set; }
    public required User Reciever { get; set; }
}

public class Role(string name) {
    public long Id { get; set; }

    public string Name { get => name; set => name = value; }
}

public class Activity {
    public long Id { get; set; }

    public required string Name { get; set; }
    public required Point Geoposition { get; set; }
    public required DateTime CreationTime { get; set; }
    public required DateTime WorkBegin { get; set; }
    public required DateTime WorkEnd { get; set; }
    public required bool CancelAge { get; set; } // what's this?

    public List<ActivityType> Types { get; set; } = [];
}

public class ActivityType {
    public long Id { get; set; }

    public required string Name { get; set; }
    public string? Decription { get; set; }

    public List<Activity> Activities { get; set; } = [];
    public List<Hobby> LinkedHobbies { get; set; } = [];
}
