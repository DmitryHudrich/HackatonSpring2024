using ServerApp.Application.Tools;
using ServerApp.Logic.Entities;
using ServerApp.Logic.Stores;
using ServerApp.Logic.Stores.Filters;

namespace ServerApp.Application.Services;

public record class RegistrationResult(bool Success, List<PasswordCheckTroubles> Issues);
//
// public class UserAuth : IAuthService<InteractResult<RegistrationResult>> {
//     public async Task<InteractResult<PasswordCheckTroubles>> Register(string login, string password) {
//         var isSuccess, issues = PasswordChecker.Check(password);
//         if (!isSuccess) {
//             return (isSuccess, new InteractResult<PasswordCheckTroubles>(issues));
//         }
//
//
//     }
// }
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
