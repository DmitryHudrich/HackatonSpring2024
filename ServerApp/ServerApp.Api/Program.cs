using NetTopologySuite.Geometries;
using ServerApp.Api;
using ServerApp.Logic;
using ServerApp.Logic.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(options => {
    _ = options.AllowAnyHeader();
    _ = options.AllowAnyMethod();
    _ = options.AllowAnyOrigin();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

RouteManager.SetEndpoints(app);

app.Run();
