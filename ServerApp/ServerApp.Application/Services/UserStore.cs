using ServerApp.Application.Tools;
using ServerApp.DataBase;
using ServerApp.Logic;
using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores;

namespace ServerApp.Application.Services;

public record class RegistrationResult(bool Success, List<PasswordCheckTroubles> Issues);

public class UserAuth(ApplicationContext dbContext) : IAuthService<RegistrationResult> {
    public async Task<IInteractResult<RegistrationResult>> Register(string login, string password) {
        (var isSuccess, var issues) = PasswordChecker.Check(password);
        if (!isSuccess) {
            return new InteractResult<RegistrationResult>(false, new RegistrationResult(false, issues));
        }


        System.Console.WriteLine("ДОБАВЛЕНИЕ БЕБРЫ");
        // заглушка
        await dbContext.Users.AddRangeAsync(new User {
            UserInfo = new UserInfo {
                Name = "sadasd",
                Bio = "sadasd",
            },
            Login = login,
            Password = password,
            RegistrationDate = DateTime.Now,
            Age = 0,
            AuthInfo = new AuthInfo {
                Web = true,
                Telegram = true
            }
        });


        _ = await dbContext.SaveChangesAsync();

        var user = dbContext.Users.Where<User>(u => u.Login == login).FirstOrDefault();
        System.Console.WriteLine(user.Id);
        return new InteractResult<RegistrationResult>(true, new RegistrationResult(true, issues));
    }

    public async Task<IInteractResult<RegistrationResult>> RegisterTelegram(ulong id) {
        var user = dbContext.Users.FirstOrDefault(u => u.TelegramId == id);
        if (user == null) {

        }
    }
}
//
// public class UserStore : IUserStore {
//     public Task AddAsync(User user) {
//         throw new NotImplementedException();
//     }
//
//     public Task AddHobby(User user, Hobby hobby) {
//         throw new NotImplementedException();
//     }
//
//     public Task ChangeGeolocation(User user, double latitude, double longtitude) {
//         throw new NotImplementedException();
//     }
//
//     public Task ChangeInfo(User user, UserInfo newInfo) {
//         throw new NotImplementedException();
//     }
//
//     public Task ChangePassword(string oldPassword, string newPassword) {
//         throw new NotImplementedException();
//     }
//
//     public Task ChangePhoto(User user, string photoBase64) {
//         throw new NotImplementedException();
//     }
//
//     public Task ChangeRole(User user, Role newRole) {
//         throw new NotImplementedException();
//     }
//
//     public Task<IReadOnlyList<User>> GetByFilterAsync<T>(UserFindFilter filter, T request) {
//         throw new NotImplementedException();
//     }
//
//     public Task RemoveAsync(User user) {
//         throw new NotImplementedException();
//     }
//
//     public Task RemoveHobby(User user, Hobby hobby) {
//         throw new NotImplementedException();
//     }
//
//     public Task SyncWithTg(User user, long telegramId) {
//         throw new NotImplementedException();
//     }
// }
