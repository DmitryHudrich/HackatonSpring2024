using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.Logic.Stores;

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


