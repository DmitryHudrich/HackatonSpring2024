using ServerApp.DataBase.Repository;
using ServerApp.Logic;
using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.Application.Services;

public class HobbyStore(HobbyRepository repository, ActivityTypeRepository activityTypeRepository) : IHobbyService {
    public async Task<IInteractResult> AddAsync(Hobby activityType) {
        await repository.AddAsync(activityType);
        return new InteractResult(true, string.Empty);
    }

    public async Task<IInteractResult> ChangeNameAsync(Hobby activityType) {
        var res = await repository.ChangeName(activityType.Id, activityType.Name);
        return new InteractResult(res, string.Empty);
    }

    public async Task<IInteractResult<IList<Hobby>>> GetAllAsync() {
        var res = await repository.GetAllAsync();
        return new InteractResult<IList<Hobby>>(true, res, string.Empty);
    }

    public async Task<IInteractResult<IReadOnlyList<Hobby>>> GetByFilterAsync<T>(HobbyFindFilter filter, T request) {
        var res = await repository.FindByFilterAsync(filter, request);
        return new InteractResult<IReadOnlyList<Hobby>>(true, (IReadOnlyList<Hobby>?)res, string.Empty);
    }

    public async Task<IInteractResult> LinkAsync(ActivityType activityType, Hobby hobby) {
        await repository.Link(activityType, hobby);
        return new InteractResult(true, string.Empty);
    }

    public async Task<IInteractResult> LinkByIdAsync(long activityId, long hobbyId) {
        var activity = await activityTypeRepository.FindByFilterAsync(ActivityTypeFindFilter.Id, activityId);
        var hobby = await repository.FindByFilterAsync(HobbyFindFilter.Id, hobbyId);
        return activity.Count == 0 || hobby.Count == 0
            ? new InteractResult(false, "Activity or hobby not found")
            : await LinkAsync(activity.FirstOrDefault()!, hobby.FirstOrDefault()!);
    }

    public async Task<IInteractResult> RemoveAsync(Hobby activityType) {
        var res = await repository.RemoveAsync(activityType.Id);
        return new InteractResult(res, string.Empty);
    }

    public async Task<IInteractResult> RemoveByIdAsync(long id) {
        _ = await repository.RemoveAsync(id);
        return new InteractResult(true, string.Empty);
    }

    public async Task<IInteractResult> UnlinkAsync(ActivityType activity, Hobby hobby) {
        await repository.Unlink(activity, hobby);
        return new InteractResult(true, string.Empty);
    }

    public async Task<IInteractResult> UnlinkByIdAsync(long activityId, long hobbyId) {
        var activity = await activityTypeRepository.FindByFilterAsync(ActivityTypeFindFilter.Id, activityId);
        var hobby = await repository.FindByFilterAsync(HobbyFindFilter.Id, hobbyId);
        await UnlinkAsync(activity.FirstOrDefault()!, hobby.FirstOrDefault()!);
        return new InteractResult(true, string.Empty);

    }
}
