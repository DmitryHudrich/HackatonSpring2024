using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.Logic.Stores;

public interface IHobbyService {
    Task<IInteractResult<IReadOnlyList<Hobby>>> GetByFilterAsync<T>(HobbyFindFilter filter, T request);
    Task<IInteractResult> ChangeNameAsync(Hobby activityType);
    Task<IInteractResult> RemoveAsync(Hobby activityType);
    Task<IInteractResult> RemoveByIdAsync(long id);
    Task<IInteractResult> AddAsync(Hobby activityType);

    Task<IInteractResult> LinkByIdAsync(long activityId, long hobbyId);
    Task<IInteractResult> LinkAsync(ActivityType activityType, Hobby hobby);
    Task<IInteractResult> UnlinkByIdAsync(long activityId, long hobbyId);
    Task<IInteractResult> UnlinkAsync(ActivityType activity, Hobby hobby);
    Task<IInteractResult<IList<Hobby>>> GetAllAsync();
}


