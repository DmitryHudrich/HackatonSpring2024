namespace ServerApp.Logic.Entities;

public class Role(string name) {
    public long Id { get; set; }

    public string Name { get => name; set => name = value; }
}

