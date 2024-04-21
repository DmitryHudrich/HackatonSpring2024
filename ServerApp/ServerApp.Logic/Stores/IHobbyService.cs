using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.Logic.Stores;

public interface IHobbyService {
    Task<IInteractResult<IReadOnlyList<Hobby>>> GetByFilterAsync<T>(HobbyFindFilter filter, T request);
    Task<IInteractResult> ChangeName(Hobby activityType, string newName);
    Task<IInteractResult> Remove(Hobby activityType);
    Task<IInteractResult> AddAsync(Hobby activityType);

    Task<IInteractResult> Link(ActivityType activityType, Hobby hobby);
    Task<IInteractResult> Unlink(ActivityType activity, Hobby hobby);
    Task<IInteractResult<IList<Hobby>>> GetAll();
}


