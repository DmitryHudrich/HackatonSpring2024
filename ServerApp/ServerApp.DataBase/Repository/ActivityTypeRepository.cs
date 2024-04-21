using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.DataBase.Repository;

public class ActivityTypeRepository(ApplicationContext dbContext) {
    public async Task<List<ActivityType>> GetAllAsync() {
        var res = dbContext.ActivityTypes.ToList();
        return res;
    }

    public async Task<bool> Remove(long activityTypeId) {
        var res = dbContext.ActivityTypes.FirstOrDefault(usr => usr.Id == activityTypeId);
        if (res == null) {
            return false;
        }
        _ = dbContext.ActivityTypes.Remove(res);
        _ = await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task AddAsync(ActivityType activityType) {
        _ = await dbContext.ActivityTypes.AddAsync(activityType);
        _ = await dbContext.SaveChangesAsync();
    }

    public async Task<bool> ChangeName(long activityTypeId, string newName) {
        var res = dbContext.ActivityTypes.FirstOrDefault(usr => usr.Id == activityTypeId);
        if (res == null) {
            return false;
        }
        res.Name = newName;
        _ = await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task Link(ActivityType activityType, Hobby hobby) {
        activityType.LinkedHobbies.Add(hobby);
        _ = await dbContext.SaveChangesAsync();
    }

    public async Task Unink(ActivityType activity, Hobby hobby) {
        _ = activity.LinkedHobbies.Remove(hobby);
        _ = await dbContext.SaveChangesAsync();
    }

    public async Task<List<ActivityType?>> FindByFilterAsync<T>(ActivityTypeFindFilter filter, T findRequest) {
        var res = filter switch {
            ActivityTypeFindFilter.Name => findRequest is string s ?
                await FindByNameAsync(s) : throw new ArgumentException("Wrong type", nameof(findRequest)),
            ActivityTypeFindFilter.Id => findRequest is long g ?
                await FindByIdAsync(g) : throw new ArgumentException("Wrong type", nameof(findRequest)),
            _ => throw new NotImplementedException(),
        };

        return res;
    }

    private async Task<List<ActivityType?>> FindByIdAsync(long g) {
        return (List<ActivityType?>)dbContext.ActivityTypes.Select(usr => usr.Id == g);
    }

    private async Task<List<ActivityType?>> FindByNameAsync(string s) {
        return (List<ActivityType?>)dbContext.ActivityTypes.Select(usr => usr.Name == s);
    }
}
