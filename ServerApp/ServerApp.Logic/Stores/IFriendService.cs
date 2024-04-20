using ServerApp.Logic.Entities;

namespace ServerApp.Logic.Stores;

public interface IFriendService {
    Task AddFriend(User user, User friendUser);
    Task RemoveFriend(User user, User friendUser);
}


