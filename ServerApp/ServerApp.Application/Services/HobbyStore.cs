using ServerApp.DataBase.Repository;
using ServerApp.Logic;
using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.Application.Services;

public class HobbyStore(HobbyRepository repository) : IHobbyService {
    public async Task<IInteractResult> AddAsync(Hobby activityType) {
        await repository.AddAsync(activityType);
        return new InteractResult(true, string.Empty);
    }

    public async Task<IInteractResult> ChangeName(Hobby activityType, string newName) {
        var res = await repository.ChangeName(activityType.Id, newName);
        return new InteractResult(res, string.Empty);
    }

    public async Task<IInteractResult<IList<Hobby>>> GetAll() {
        var res = await repository.GetAllAsync();
        return new InteractResult<IList<Hobby>>(true, res, string.Empty);
    }

    public async Task<IInteractResult<IReadOnlyList<Hobby?>>> GetByFilterAsync<T>(HobbyFindFilter filter, T request) {
        var res = await repository.FindByFilterAsync(filter, request);
        return new InteractResult<IReadOnlyList<Hobby?>>(true, (IReadOnlyList<Hobby?>?)res, string.Empty);
    }

    public async Task<IInteractResult> Link(ActivityType activityType, Hobby hobby) {
        await repository.Link(activityType, hobby);
        return new InteractResult(true, string.Empty);
    }

    public async Task<IInteractResult> Remove(Hobby activityType) {
        var res = await repository.Remove(activityType.Id);
        return new InteractResult(res, string.Empty);
    }

    public async Task<IInteractResult> Unlink(ActivityType activity, Hobby hobby) {
        await repository.Unlink(activity, hobby);
        return new InteractResult(true, string.Empty);
    }
}
