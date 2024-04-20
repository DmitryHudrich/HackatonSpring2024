namespace ServerApp.Logic.Entities;

public class Visit {
    public long Id { get; set; }

    public required DateTime VisitTime { get; set; }
    public required Activity Activity { get; set; }
    public required Route Route { get; set; }
}
