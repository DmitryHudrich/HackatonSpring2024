using Microsoft.AspNetCore.Authorization;
using ServerApp.Api.DataTransferObjects.Request;
using ServerApp.Logic.Stores;

namespace ServerApp.Api.RouteManagers;

public static class ActivityTypeRouteManager {
    private static WebApplication app = null!;


    public static void SetEndpoints(WebApplication app) {
        ActivityTypeRouteManager.app = app;

        _ = app.MapGet("/activity/all", (IHobbyService hobbyService) =>
                hobbyService.GetAllAsync());
        _ = app.MapGet("/activity/byname/{name}", async (string name, IHobbyService hobbyService) =>
                await hobbyService.GetByFilterAsync(Logic.Stores.Filters.HobbyFindFilter.Name, name));
        _ = app.MapGet("/activity/byid/{id}", async (long id, IHobbyService hobbyService) =>
                await hobbyService.GetByFilterAsync(Logic.Stores.Filters.HobbyFindFilter.Id, id));

        _ = app.MapPost("/activity", [Authorize(Roles = "admin")] async (NewHobbyRequest newHobby, IHobbyService hobbyService) => {
            _ = await hobbyService.AddAsync(new Logic.Entities.Hobby {
                Name = newHobby.Name
            });
        });

        _ = app.MapDelete("/activity/delete/{id}", [Authorize(Roles = "admin")] async (long id, IHobbyService hobbyService) => {
            _ = await hobbyService.RemoveByIdAsync(id);
        });

        _ = app.MapPut("/activity/change/{id}", [Authorize(Roles = "admin")] async (long id, NewHobbyRequest newHobby, IHobbyService hobbyService) => {
            _ = await hobbyService.ChangeNameAsync(new Logic.Entities.Hobby { Id = id, Name = newHobby.Name });
        });

        _ = app.MapPost("/activity/link/{activityId}/{hobbyId}", [Authorize(Roles = "admin")] async (long activityId, long hobbyId, IHobbyService hobbyService) => {
            _ = await hobbyService.LinkByIdAsync(activityId, hobbyId);
        });

        _ = app.MapDelete("/activity/unlink/{activityId}/{hobbyId}", [Authorize(Roles = "admin")] async (long activityId, long hobbyId, IHobbyService hobbyService) => {
            _ = await hobbyService.UnlinkByIdAsync(activityId, hobbyId);
        });

        _ = app.MapGet("/hobby/all", async (IHobbyService hobbyService) => await hobbyService.GetAllAsync());

        _ = app.MapGet("/hobby/byname/{name}", async (string name, IHobbyService hobbyService) => await hobbyService.GetByFilterAsync(Logic.Stores.Filters.HobbyFindFilter.Name, name));

        _ = app.MapGet("/hobby/byid/{id}", async (long id, IHobbyService hobbyService) => await hobbyService.GetByFilterAsync(Logic.Stores.Filters.HobbyFindFilter.Id, id));

        _ = app.MapPost("/hobby", [Authorize(Roles = "admin")] async (NewHobbyRequest newHobby, IHobbyService hobbyService) => {
            _ = await hobbyService.AddAsync(new Logic.Entities.Hobby { Name = newHobby.Name });
        });
    }
}
