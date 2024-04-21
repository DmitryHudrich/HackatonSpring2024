using ServerApp.Logic.Entities;

namespace ServerApp.DataBase.Repository;

public class UserRepository(ApplicationContext dbContext) {
    public async Task<bool> UpdateRefresh(User user) {
        _ = dbContext.Users.Update(user);
        return await dbContext.SaveChangesAsync() > 0;
    }
}
