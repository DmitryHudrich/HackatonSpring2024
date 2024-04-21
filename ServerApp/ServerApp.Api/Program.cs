using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using ServerApp.Api;
using ServerApp.Application;
using ServerApp.Application.Services;
using ServerApp.Application.Tools;
using ServerApp.Application.Tools.StaticStuff;
using ServerApp.DataBase;
using ServerApp.DataBase.Repository;
using ServerApp.Logic.Stores;

System.Console.WriteLine(System.Environment.GetEnvironmentVariable("PROD_CONTAINER"));
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
            // указывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = true,
            // строка, представляющая издателя
            ValidIssuer = ApplicationOptions.JwtOptions.Issuer,
            // будет ли валидироваться потребитель токена
            ValidateAudience = true,
            // установка потребителя токена
            ValidAudience = ApplicationOptions.JwtOptions.Audience,
            // будет ли валидироваться время существования
            ValidateLifetime = true,
            // установка ключа безопасности
            IssuerSigningKey = ApplicationOptions.JwtOptions.GetSymmetricSecurityKey(),
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
        };
    });

// Application.SetServices(ref builder.Services);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// закостыляли малеха не смогли разобраться 
builder.Services.AddNpgsql<ApplicationContext>(
        //"Host=172.21.0.3;Port=5432;Database=usersdb;Username=postgres;Password=12345",
        "Host=hackatonspring2024-postgres-1;Port=5432;Database=usersdb;Username=postgres;Password=12345",
        builder =>
        builder.UseNetTopologySuite());

_ = builder.Services.AddScoped<IHobbyService, HobbyStore>();
_ = builder.Services.AddScoped<ActivityTypeRepository>();
_ = builder.Services.AddScoped<HobbyRepository>();
_ = builder.Services.AddScoped<UserRepository>();
_ = builder.Services.AddScoped<JwtService>();
_ = builder.Services.AddScoped<IAuthService, UserAuth>();

builder.Services.AddCors();
builder.Services.AddLogging();

var app = builder.Build();

var core = new Application(app.Services);
app.UseCors(options => {
    _ = options.AllowAnyHeader();
    _ = options.AllowAnyMethod();
    _ = options.AllowAnyOrigin();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || System.Environment.GetEnvironmentVariable("PROD_CONTAINER") == "PROD") {
    _ = app.UseSwagger(); _ = app.UseSwaggerUI();
    _ = app.UseSwaggerUI();
}
app.UseHttpsRedirection();

RouteManager.SetEndpoints(app);

app.Run();
