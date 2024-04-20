namespace ServerApp.Logic;

public interface IInteractResult<T> {
    bool Success { get; init; }
    T? Value { get; init; }
    string? ErrorMessage { get; init; }
}
public interface IInteractResult {
    bool Success { get; init; }
    string? ErrorMessage { get; init; }
}

