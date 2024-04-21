using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.Logic.Stores;

public interface IActivityTypeService {
    Task<IInteractResult<IReadOnlyList<ActivityType>>> GetByFilterAsync<T>(ActivityTypeFindFilter filter, T request);
    Task<IInteractResult> ChangeName(ActivityType activityType, string newName);
    Task<IInteractResult> Remove(ActivityType activityType);
    Task<IInteractResult> AddAsync(ActivityType activityType);

    Task<IInteractResult> Link(ActivityType activityType, Hobby hobby);
    Task<IInteractResult> Unink(ActivityType activity, Hobby hobby);
    Task<IInteractResult<IList<ActivityType>>> GetAll();
}

