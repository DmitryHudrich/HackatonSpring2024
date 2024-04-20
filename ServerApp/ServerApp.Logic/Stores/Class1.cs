using ServerApp.Logic.Entities;

namespace ServerApp.Logic.Stores;

public enum UserFindFilter {
    Id,
}

public enum ActivityFindFilter {
    Id,
}

public enum HobbyFindFilter {
    Id,
}

public enum ActivityTypeFindFilter {
    Id,
}

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

public interface IFriendService {
    Task AddFriend(User user, User friendUser);
    Task RemoveFriend(User user, User friendUser);
}

public interface IActivityStore {
    Task<IReadOnlyList<Activity>> GetByFilterAsync<T>(ActivityFindFilter filter, T request);
    Task<bool> AddAsync(Activity activity);
    Task RemoveAsync(Activity activity);
    Task ChangeGeolocation(Activity activity, double latitude, double longtitude);
    Task ChangeWorkTime(Activity activity, DateTime begin, DateTime endTime);
    Task ChangeInfo(Activity activity, ActivityInfo newInfo);

    Task AddType(Activity activity, ActivityType activityType);
    Task RemoveType(Activity activity, ActivityType activityType);
}

public interface IHobbyService {
    Task<IReadOnlyList<Hobby>> GetByFilterAsync<T>(HobbyFindFilter filter, T request);
    Task ChangeName(Hobby hobby, string newName);
    Task Remove(Hobby hobby);
    Task<bool> Add(Hobby hobby);

    Task<bool> Link(Hobby hobby, ActivityType activityType);
    Task<bool> Unink(Hobby hobby, ActivityType activityType);
}

public interface IActivityTypeService {
    Task<IReadOnlyList<ActivityType>> GetByFilterAsync<T>(ActivityTypeFindFilter filter, T request);
    Task ChangeName(ActivityType activityType, string newName);
    Task Remove(ActivityType activityType);
    Task<bool> Add(ActivityType activityType);

    Task<bool> Link(ActivityType activityType, Hobby hobby);
    Task<bool> Unink(ActivityType activity, Hobby hobby);
}

