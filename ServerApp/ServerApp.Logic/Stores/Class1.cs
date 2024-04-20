using ServerApp.Logic.Entities;

namespace ServerApp.Logic.Stores;

public enum FindFilter {
    Id,
}

public interface IUserStore {
    Task<IReadOnlyList<User>> GetByFilter<T>(FindFilter filter, T request);

}
