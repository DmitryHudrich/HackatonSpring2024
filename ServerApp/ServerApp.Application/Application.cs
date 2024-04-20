using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using ServerApp.DataBase;

namespace ServerApp.Application;

public sealed class Application(IServiceProvider services) {
    public IServiceProvider Services { get; set; } = services;

    public static void SetServices(IServiceCollection services) {
        _ = services.AddNpgsqlDataSource(
            @"
            Host=pg_server;
            Username=test;
            Password=test;
            Database=test
            ",
            builder => builder
                .UseNetTopologySuite());

        _ = services.AddDbContext<ApplicationContext>();
    }
}
