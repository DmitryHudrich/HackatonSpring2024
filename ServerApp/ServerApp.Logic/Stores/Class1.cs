using ServerApp.Logic.Entities;

namespace ServerApp.Logic.Stores;

public enum FindFilter {
    Id,
}

public interface IUserStore {
    Task<IReadOnlyList<User>> GetByFilterAsync<T>(FindFilter filter, T request);
    Task AddAsync(User user);
    Task RemoveAsync(User user);
    Task UpdateAsync(User oldUser, User newUser);
}
