using ServerApp.Application.Tools;
using ServerApp.Application.Tools.StaticStuff;
using ServerApp.DataBase;
using ServerApp.Logic;
using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores;

namespace ServerApp.Application.Services;

public record class RegistrationResult(bool Success, List<PasswordCheckTroubles> Issues, string? Jwt = default);

public class UserAuth(ApplicationContext dbContext, JwtService jwtService) : IAuthService<RegistrationResult> {
    public Task<IInteractResult<RegistrationResult>> Register(string login, string password) {
        throw new NotImplementedException();
    }

    public async Task<IInteractResult<RegistrationResult>> RegisterTelegram(HttpContext httpContext, ulong id, string? firstName = default, string? lastName = default, string? bio = default, string? photoBase64 = default) {
        var user = dbContext.Users.FirstOrDefault(u => u.TelegramId == id);

        if (user == null) {
            user = new User {
                UserInfo = new UserInfo {
                    FirstName = firstName,
                    LastName = lastName,
                    Bio = bio,
                },
                TelegramId = id,
                RegistrationDate = DateTime.Now,
                AuthInfo = new AuthInfo {
                    Telegram = true,
                },
                PhotoBase64 = photoBase64
            };

            _ = await dbContext.Users.AddAsync(user);
        }

        var jwt = jwtService.GenerateJwtToken(user, httpContext, ApplicationOptions.SecureCookieOptions);
        _ = await dbContext.SaveChangesAsync();
        return new InteractResult<RegistrationResult>(true, new RegistrationResult(true, [], jwt));
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
