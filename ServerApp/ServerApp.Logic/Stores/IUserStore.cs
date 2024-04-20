using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.Logic.Stores;

public interface IUserStore {
    Task<IReadOnlyList<User>> GetByFilterAsync<T>(UserFindFilter filter, T request);
    Task AddAsync(User user);
    Task RemoveAsync(User user);
    Task ChangePhoto(User user, string photoBase64);
    Task ChangePassword(string oldPassword, string newPassword);
    Task ChangeInfo(User user, UserInfo newInfo);
    Task ChangeRole(User user, Role newRole);
    Task ChangeGeolocation(User user, double latitude, double longtitude);
    Task AddHobby(User user, Hobby hobby);
    Task RemoveHobby(User user, Hobby hobby);
    Task SyncWithTg(User user, long telegramId);
}


