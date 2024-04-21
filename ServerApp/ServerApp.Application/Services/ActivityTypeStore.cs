using ServerApp.DataBase.Repository;
using ServerApp.Logic;
using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.Application.Services;


public class ActivityTypeStore(ActivityTypeRepository repository) : IActivityTypeService {
    public async Task<IInteractResult> AddAsync(ActivityType activityType) {
        await repository.AddAsync(activityType);
        return new InteractResult(true, string.Empty);
    }

    public async Task<IInteractResult> ChangeName(ActivityType activityType, string newName) {
        var res = await repository.ChangeName(activityType.Id, newName);
        return new InteractResult(res, string.Empty);
    }

    public async Task<IInteractResult<IList<ActivityType>>> GetAll() {
        var res = await repository.GetAllAsync();
        return new InteractResult<IList<ActivityType>>(true, res, string.Empty);
    }

    public async Task<IInteractResult<IReadOnlyList<ActivityType?>>> GetByFilterAsync<T>(ActivityTypeFindFilter filter, T request) {
        var res = await repository.FindByFilterAsync(filter, request);
        return new InteractResult<IReadOnlyList<ActivityType?>>(true, res, string.Empty);
    }

    public async Task<IInteractResult> Link(ActivityType activityType, Hobby hobby) {
        await repository.Link(activityType, hobby);
        return new InteractResult(true, string.Empty);
    }

    public async Task<IInteractResult> Remove(ActivityType activityType) {
        var res = await repository.Remove(activityType.Id);
        return new InteractResult(res, string.Empty);
    }

    public async Task<IInteractResult> Unink(ActivityType activity, Hobby hobby) {
        await repository.Unink(activity, hobby);
        return new InteractResult(true, string.Empty);
    }
}
