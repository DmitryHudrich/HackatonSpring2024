using NetTopologySuite.Geometries;
using ServerApp.Logic;
using ServerApp.Logic.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

// using var db = new ApplicationContext();
// var user = new User {
//     Name = "asd",
//     Login = "john.doe",
//     Password = "password123",
//     PhotoBase64 = "photoBase64String",
//     RegistrationDate = DateTime.Now,
//     Age = 30,
//     Role = new Role("User"),
//     SearchGeoposition = new Point(40.7128, -74.0060),
// };
//
// User user1 = new User {
//     Name = "asd",
//     Login = "john.doe",
//     Password = "password123",
//     PhotoBase64 = "photoBase64String",
//     RegistrationDate = DateTime.Now,
//     Age = 30,
//     Role = new Role("User"),
//     SearchGeoposition = new Point(40.7128, -74.0060),
// };
//
// var hobby1 = new Hobby {
//     Name = "Hiking",
// };
//
// var friendsPair1 = new FriendsPair {
//     Sender = user1,
//     Reciever = user
// };
// var role1 = new Role("Admin") { };
// var activity1 = new Activity {
//     Id = 1,
//     Name = "Hiking in the mountains",
//     Geoposition = new Point(39.5501, -105.7821),
//     CreationTime = DateTime.Now,
//     WorkBegin = DateTime.Now,
//     WorkEnd = DateTime.Now,
//     CancelAge = false,
// };
// var activityType1 = new ActivityType {
//     Name = "Outdoor",
//     Decription = "Activities in the open air",
// };
//
// db.Activities.AddRange(activity1);
// db.ActivityTypes.AddRange(activityType1);
// db.Roles.AddRange(role1);
// db.FriendsPairs.AddRange(friendsPair1);
// db.Hobbies.AddRange(hobby1);
// db.Users.AddRange(user, user1);
//
// db.SaveChanges();

app.UseHttpsRedirection();

var summaries = new[] {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () => {
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary) {
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
