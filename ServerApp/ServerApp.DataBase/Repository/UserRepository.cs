using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.DataBase.Repository;

public class UserRepository(ApplicationContext dbContext) {
    public async Task<bool> UpdateRefreshAsync(User user) {
        var res = dbContext.Users.FirstOrDefault(usr => usr.Id == user.Id);
        if (res == null) {
            return false;
        }
        res.RefreshTokenExpiration = user.RefreshTokenExpiration;
        res.RefreshTokenData = user.RefreshTokenData;
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task AddAsync(User user) {
        _ = await dbContext.Users.AddAsync(user);
        _ = await dbContext.SaveChangesAsync();
    }

    public async Task<User?> FindByFilterAsync<T>(UserFindFilter filter, T findRequest) {
        var res = filter switch {
            UserFindFilter.Login => findRequest is string s ?
                await FindByLoginAsync(s) : throw new ArgumentException("Wrong type", nameof(findRequest)),
            UserFindFilter.Id => findRequest is long g ?
                await FindByIdAsync(g) : throw new ArgumentException("Wrong type", nameof(findRequest)),
            UserFindFilter.Refresh => findRequest is string s ?
                await FindByRefreshTokenAsync(s) : throw new ArgumentException("Wrong type", nameof(findRequest)),
            UserFindFilter.Suitability => throw new NotImplementedException(),
            _ => default
        };
        return res;
    }

    private async Task<User?> FindByLoginAsync(string s) {
        return dbContext.Users.FirstOrDefault(usr => usr.Login == s);
    }

    private Task<User?> FindByRefreshTokenAsync(string s) {
        return Task.FromResult(dbContext.Users.FirstOrDefault(usr => usr.RefreshTokenData == s));
    }

    private Task<User?> FindByIdAsync(long g) {
        return Task.FromResult(dbContext.Users.FirstOrDefault(usr => usr.Id == g));
    }
}
