using System.Security.Claims;
using ServerApp.Application.Tools;
using ServerApp.Application.Tools.StaticStuff;
using ServerApp.DataBase;
using ServerApp.DataBase.Repository;
using ServerApp.Logic;
using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.Application.Services;

public class UserAuth(UserRepository repository, JwtService jwtService) : IAuthService {
    public async Task<IInteractResult<string>> Login(HttpContext httpContext, string login, string password) {
        var user = await repository.FindByFilterAsync(UserFindFilter.Login, login);
        if (user == null) {
            return new InteractResult<string>(Success: false, ErrorMessage: "User not found", Value: null);
        }
        if (!BCrypt.Net.BCrypt.Verify(password, user.Password)) {
            return new InteractResult<string>(Success: false, ErrorMessage: "Wrong password", Value: null);
        }
        var jwt = await jwtService.GenerateJwtTokenAsync(user, httpContext, ApplicationOptions.SecureCookieOptions);
        return new InteractResult<string>(Success: true, ErrorMessage: "Success", Value: jwt);
    }

    public async Task<IInteractResult<string>> Refresh(HttpContext httpContext) {
        var user = await repository.FindByFilterAsync(UserFindFilter.Refresh, httpContext.Request.Cookies["X-Refresh"] ?? string.Empty);
        if (user == null) {
            return new InteractResult<string>(Success: false, ErrorMessage: "User not found", Value: null);
        }
        var jwt = await jwtService.GenerateJwtTokenAsync(user, httpContext, ApplicationOptions.SecureCookieOptions);
        return new InteractResult<string>(Success: true, ErrorMessage: "Success", Value: jwt);
    }

    public async Task<IInteractResult<string>> Register(string login, string password, string? firstName = default, string? lastName = default, string? bio = default, string? photoBase64 = default) {
        var user = await repository.FindByFilterAsync(UserFindFilter.Login, login);
        if (user != null) {
            return new InteractResult<string>(Success: false, ErrorMessage: "User with this login already exists", Value: "");
        }

        if (user == null) {
            user = new User {
                Login = login,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                UserInfo = new UserInfo {
                    FirstName = firstName,
                    LastName = lastName,
                    Bio = bio,
                },
                RegistrationDate = DateTime.Now,
                AuthInfo = new AuthInfo {
                    Web = true,
                },
                PhotoBase64 = photoBase64
            };

            await repository.AddAsync(user);
        }

        return new InteractResult<string>(true, string.Empty, string.Empty);
    }

    public async Task<IInteractResult<string>> RegisterTelegram(HttpContext httpContext, ulong id, string? firstName = default, string? lastName = default, string? bio = default, string? photoBase64 = default) {
        var user = await repository.FindByFilterAsync(UserFindFilter.Id, (long)id);

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

            await repository.AddAsync(user);
        }

        var jwt = await jwtService.GenerateJwtTokenAsync(user, httpContext, ApplicationOptions.SecureCookieOptions);
        return new InteractResult<string>(true, string.Empty, jwt);
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
