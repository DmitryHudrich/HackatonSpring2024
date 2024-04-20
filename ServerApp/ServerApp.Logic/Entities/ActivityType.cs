namespace ServerApp.Logic.Entities;

public class ActivityType {
    public long Id { get; set; }

    public required string Name { get; set; }
    public string? Decription { get; set; }

    public List<Activity> Activities { get; set; } = [];
    public List<Hobby> LinkedHobbies { get; set; } = [];
}

