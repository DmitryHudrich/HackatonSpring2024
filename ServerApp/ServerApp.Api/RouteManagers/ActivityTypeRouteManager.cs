using ServerApp.Logic.Stores;

namespace ServerApp.Api.RouteManagers;

public static class ActivityTypeRouteManager {
    private static WebApplication app = null!;


    public static void SetEndpoints(WebApplication app) {
        ActivityTypeRouteManager.app = app;

        _ = app.MapGet("/activity/alltypes", (IHobbyService hobbyService) =>
                hobbyService.GetAll());
        _ = app.MapGet("/activity/byname/{name}", async (string name, IHobbyService hobbyService) =>
                await hobbyService.GetByFilterAsync(Logic.Stores.Filters.HobbyFindFilter.Name, name));
        _ = app.MapGet("/activity/byid/{id}", async (long id, IHobbyService hobbyService) =>
                await hobbyService.GetByFilterAsync(Logic.Stores.Filters.HobbyFindFilter.Id, id));
    }
}
