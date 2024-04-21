using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Npgsql;
using ServerApp.Api;
using ServerApp.Application;
using ServerApp.Application.Services;
using ServerApp.Application.Tools;
using ServerApp.DataBase;
using ServerApp.DataBase.Repository;
using ServerApp.Logic.Stores;

System.Console.WriteLine(System.Environment.GetEnvironmentVariable("PROD_CONTAINER"));
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


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
        "Host=172.21.0.3;Port=5432;Database=usersdb;Username=postgres;Password=12345",
        builder =>
        builder.UseNetTopologySuite());



_ = builder.Services.AddScoped<UserRepository>();
_ = builder.Services.AddScoped<JwtService>();
_ = builder.Services.AddScoped<IAuthService<RegistrationResult>, UserAuth>();

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
