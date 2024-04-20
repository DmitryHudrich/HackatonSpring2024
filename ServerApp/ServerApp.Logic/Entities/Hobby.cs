namespace ServerApp.Logic.Entities;

public class Hobby {
    public long Id { get; set; }
    public required string Name { get; set; }

    public List<User> HobbyOwners { get; set; } = [];
    public List<ActivityType> LinkedActivityTypes { get; set; } = [];
}

