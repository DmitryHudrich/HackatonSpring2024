namespace ServerApp.Application;

public record class InteractResult<T>(bool Success, T? Data = default, string? Error = default) {
    public static explicit operator T?(InteractResult<T> res) => res.Data ?? default;
};
public record class InteractResult(bool Success, string? Error = default);
