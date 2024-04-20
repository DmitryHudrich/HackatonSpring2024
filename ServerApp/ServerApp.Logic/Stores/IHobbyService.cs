using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.Logic.Stores;

public interface IHobbyService {
    Task<IReadOnlyList<Hobby>> GetByFilterAsync<T>(HobbyFindFilter filter, T request);
    Task ChangeName(Hobby hobby, string newName);
    Task Remove(Hobby hobby);
    Task<bool> Add(Hobby hobby);

    Task<bool> Link(Hobby hobby, ActivityType activityType);
    Task<bool> Unink(Hobby hobby, ActivityType activityType);
}


