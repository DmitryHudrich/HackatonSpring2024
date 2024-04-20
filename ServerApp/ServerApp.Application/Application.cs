using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServerApp.Application.Services;
using ServerApp.DataBase;
using ServerApp.Logic.Stores;

namespace ServerApp.Application;

public sealed class Application(IServiceProvider services) {
    public IServiceProvider Services { get; set; } = services;

    public static void SetServices(ref IServiceCollection services) {

    }
}
