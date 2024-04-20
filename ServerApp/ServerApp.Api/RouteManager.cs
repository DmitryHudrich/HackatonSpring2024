using Microsoft.AspNetCore.Mvc;
using ServerApp.Api.DataTransferObjects.Request;
using ServerApp.Api.DataTransferObjects.Response;
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
            return Results.NotFound($"201 - if account created; 403 - if login already exists");
        });

        _ = app.MapPost("/auth/login", (LoginRequest dto) => {
            _ = Results.NotFound("200 - succesfull login and returned SuccesLoginResponse dto. refresh token will be in `X-Refresh` cookie; 400 - something went wrong; 403 - wrong password");
        });

        _ = app.MapGet("/auth/refresh", () => Results.NotFound("200 - if cookie has a X-Refresh with a valide value and return SuccessLoginResponse dto, oterwise 403"));

        _ = app.MapPost("/auth/registration/telegram", (TelegramRegistrationRequest dto) => Results.NotFound("always 200 and returns SuccessLoginResponse dto"));

        _ = app.MapPut("/auth/sync/telegram", (TelegramSyncRequest dto) => Results.NotFound("always 200"));



        //
        _ = app.MapGet("/forswagger/dont/send/this/anywhere", (
                    [FromBody] SuccessLoginResponse one
                    ) => Results.NotFound());
    }

    public static void User() {
        _ app.MapGet("/user/{id}", (long id) => Results.NotFound(""))
    }
}
