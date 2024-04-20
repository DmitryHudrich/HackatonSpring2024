namespace ServerApp.Logic.Entities;

public class Route {
    public long Id { get; set; }

    public required string Name { get; set; }

    public DateTime CreationDate { get; set; }
    public DateTime StartTime { get; set; }
    public required User Creator { get; set; }

    public List<Activity> Activities { get; set; } = [];
}
