using ServerApp.Logic.Entities;

namespace ServerApp.DataBase.Repository;

public class UserRepository(ApplicationContext dbContext) {
    public async Task<bool> AddAsync(User user) {
        throw new NotImplementedException();
    }
}
