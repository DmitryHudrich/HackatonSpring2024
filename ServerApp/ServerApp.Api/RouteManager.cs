﻿using Microsoft.AspNetCore.Authorization;
using ServerApp.Api.DataTransferObjects.Request;
using ServerApp.Api.DataTransferObjects.Response;
using ServerApp.Api.RouteManagers;
using ServerApp.Api.Stuff;
using ServerApp.Logic.Stores;

namespace ServerApp.Api;

internal static class RouteManager {
    private static WebApplication app = null!;

    public static void SetEndpoints(WebApplication app) {
        RouteManager.app = app;

        ActivityTypeRouteManager.SetEndpoints(app);
        Auth();
        User();

    }

    public static void Auth() {
        _ = app.MapGet("/admin", [Authorize(Roles = "admin")] () => "овсянкин");

        _ = app.MapPost("/auth/registration", async (RegistrationRequest dto, IAuthService authService) => {
            var res = await authService.Register(dto.Login, dto.Password, dto.FirstName, dto.LastName, dto.Bio, dto.PhotoBase64);
            return res.Success
                ? Results.StatusCode(201)
                : Results.StatusCode(403);
        }).WithOpenApi(operation => new(operation) {
            Summary = "Register user with login and password",
            Description = "201 - if user created \n403 - otherwise"
        });

        _ = app.MapPost("/auth/login", async (HttpContext context, LoginRequest dto, IAuthService authService) => {
            var res = await authService.Login(context, dto.Login, dto.Password);
            return res.Success
                ? Results.Ok(res) :
                Results.StatusCode(403);
        }).WithOpenApi(operation => new(operation) {
            Summary = "Login user with login and password",
            Description = $"200 - succes login and return\n403 - wrong password\n 400 - otherwise. With 200 sends jwt token in body and refresh token in cookie '{Constants.REFRESH_COOKIE}'"
        }).Produces<SuccessLoginResponse>();

        _ = app.MapGet("/auth/refresh", async (HttpContext context, IAuthService authService) => {
            var res = await authService.Refresh(context);
            return res.Success
                ? Results.Ok(res)
                : Results.StatusCode(403);
        })
            .WithOpenApi(operation => new(operation) {
                Summary = "Refreshes jwt",
                Description = "200 - success; 403 - otherwise. With 200 sends jwt token in body and refresh token in cookie '{Constants.REFRESH_COOKIE}'"
            })
            .Produces<SuccessLoginResponse>();

        _ = app.MapPost("/auth/registration/telegram", async (HttpContext context, TelegramRegistrationRequest dto, IAuthService authService) => {
            var res = await authService.RegisterTelegram(context, dto.TelegramId, dto.FirstName, dto.LastName, dto.Bio, dto.PhotoBase64);
            return res;
        })
            .WithOpenApi(operation => new(operation) {
                Summary = "Register user with telegram id",
                Description = $"always 200. sends jwt in body in refresh in {Constants.REFRESH_COOKIE} cookie"
            })
            .Produces<TelegramRegistrationRequest>();

        _ = app.MapPut("/auth/sync/telegram", (TelegramSyncRequest dto) => Results.NoContent());
    }

    public static void User() {
        _ = app.MapGet("/user/{id}", (long id) =>
                Results.NotFound("200 - if user was found and returns UserDataResponse; 400 - otherwise"));

        _ = app.MapGet("/user/{id}/friends", () => Results.NotFound(new FriendsResponse([])));

    }
}
