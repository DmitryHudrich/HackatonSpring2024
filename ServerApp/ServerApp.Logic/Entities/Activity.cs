using NetTopologySuite.Geometries;

namespace ServerApp.Logic.Entities;

public class Activity {
    public long Id { get; set; }

    public required ActivityInfo ActivityInfo { get; set; }
    public required Point Geoposition { get; set; }
    public required DateTime CreationTime { get; set; }
    public required DateTime WorkBegin { get; set; }
    public required DateTime WorkEnd { get; set; }
    public required bool CancelAge { get; set; } // what's this?

    public List<ActivityType> Types { get; set; } = [];
}

public class ActivityInfo {
    public required string Name { get; set; }
    public required string Description { get; set; }
}

