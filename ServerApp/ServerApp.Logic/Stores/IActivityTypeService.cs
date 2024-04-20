using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.Logic.Stores;

public interface IActivityTypeService {
    Task<IReadOnlyList<ActivityType>> GetByFilterAsync<T>(ActivityTypeFindFilter filter, T request);
    Task ChangeName(ActivityType activityType, string newName);
    Task Remove(ActivityType activityType);
    Task<bool> Add(ActivityType activityType);

    Task<bool> Link(ActivityType activityType, Hobby hobby);
    Task<bool> Unink(ActivityType activity, Hobby hobby);
}

