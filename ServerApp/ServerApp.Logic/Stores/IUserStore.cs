using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.Logic.Stores;

public interface IUserStore {
    Task<IReadOnlyList<IInteractResult<User>>> GetByFilterAsync<T>(UserFindFilter filter, T request);
    Task<IInteractResult> AddAsync(User user);
    Task<IInteractResult> RemoveAsync(User user);
    Task<IInteractResult> ChangePhoto(User user, string photoBase64);
    Task<IInteractResult> ChangePassword(string oldPassword, string newPassword);
    Task<IInteractResult> ChangeInfo(User user, UserInfo newInfo);
    Task<IInteractResult> ChangeRole(User user, Role newRole);
    Task<IInteractResult> ChangeGeolocation(User user, double latitude, double longtitude);
    Task<IInteractResult> AddHobby(User user, Hobby hobby);
    Task<IInteractResult> RemoveHobby(User user, Hobby hobby);
    Task<IInteractResult> SyncWithTg(User user, long telegramId);
}

