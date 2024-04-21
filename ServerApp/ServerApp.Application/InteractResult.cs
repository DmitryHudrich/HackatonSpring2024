using ServerApp.Logic;

namespace ServerApp.Application;

public record class InteractResult<T>(bool Success, T? Value = default, string? ErrorMessage = default) : IInteractResult<T> {
    public static explicit operator T?(InteractResult<T> res) => res.Value ?? default;
};
public record class InteractResult(bool Success, string? ErrorMessage = default) : IInteractResult;
