using ServerApp.Logic.Entities;

namespace ServerApp.DataBase.Repository;

public class UserRepository(ApplicationContext dbContext) {
    public async Task<bool> UpdateRefresh(User user) {
        var res = dbContext.Users.FirstOrDefault(usr => usr.Id == user.Id);
        if (res == null) {
            return false;
        }
        res.RefreshTokenExpiration = user.RefreshTokenExpiration;
        res.RefreshTokenData = user.RefreshTokenData;
        return await dbContext.SaveChangesAsync() > 0;
    }
}
