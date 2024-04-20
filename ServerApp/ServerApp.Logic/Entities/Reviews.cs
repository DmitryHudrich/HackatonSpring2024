namespace ServerApp.Logic.Entities;

public class Reviews {
    public long Id { get; set; }

    public required string Title { get; set; }
    public required string Text { get; set; }

    public required DateTime CreationTime { get; set; }

    public required bool IsGood { get; set; }

    public required User Author { get; set; }
}
