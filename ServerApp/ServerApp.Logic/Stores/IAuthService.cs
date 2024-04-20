﻿namespace ServerApp.Logic.Stores;

public interface IAuthService<TResultInfo> {
    Task<IInteractResult<TResultInfo>> Register(string login, string password);
}
