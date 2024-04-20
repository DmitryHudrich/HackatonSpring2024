using Microsoft.AspNetCore.Mvc;
using ServerApp.Api.DataTransferObjects.Request;
using ServerApp.Api.DataTransferObjects.Response;
using ServerApp.Api.Stuff;
namespace ServerApp.Api;

internal static class RouteManager {
    private static WebApplication app = null!;

    public static void SetEndpoints(WebApplication app) {
        RouteManager.app = app;

        Auth();
        User();
    }

    public static void Auth() {
        _ = app.MapPost("/auth/registration", (RegistrationRequest dto) => {
        }).WithOpenApi(operation => new(operation) {
            Summary = "Register user with login and password",
            Description = "201 - if user created \n403 - otherwise"
        });

        _ = app.MapPost("/auth/login", (LoginRequest dto) => {
            return Results.NotFound(new SuccessLoginResponse("TOKEN"));
        }).WithOpenApi(operation => new(operation) {
            Summary = "Login user with login and password",
            Description = $"200 - succes login and return\n403 - wrong password\n 400 - otherwise. With 200 sends jwt token in body and refresh token in cookie '{Constants.REFRESH_COOKIE}'"
        });

        _ = app.MapGet("/auth/refresh", () => Results.NotFound(new SuccessLoginResponse("TOKEN")))
            .WithOpenApi(operation => new(operation) {
                Summary = "Refreshes jwt",
                Description = "200 - success; 403 - otherwise. With 200 sends jwt token in body and refresh token in cookie '{Constants.REFRESH_COOKIE}'"
            });

        _ = app.MapPost("/auth/registration/telegram", (TelegramRegistrationRequest dto) => Results.NotFound(new TelegramRegistrationRequest(0)))
   .WithOpenApi(operation => new(operation) {
       Summary = "Register user with telegram id",
       Description = $"always 200. sends jwt in body in refresh in {Constants.REFRESH_COOKIE} cookie"
   });
        _ = app.MapPut("/auth/sync/telegram", (TelegramSyncRequest dto) => Results.NoContent());

        //
        _ = app.MapGet("/forswagger/dont/send/this/anywhere", (
                    [FromBody] SuccessLoginResponse one
                    ) => Results.NotFound());


        //
        _ = app.MapGet("/forswagger/dont/send/this/anywhere/q", (
                    [FromBody] FriendsResponse one
                    ) => Results.NotFound());
    }

    public static void User() {
        _ = app.MapGet("/user/{id}", (long id) =>
                Results.NotFound("200 - if user was found and returns UserDataResponse; 400 - otherwise"));

        _ = app.MapGet("/user/{id}/friends", () => Results.NotFound(new Friends([]));
    }
}
