using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using MyApi.src.Services;

var builder = WebApplication.CreateBuilder(args);

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("Content-Disposition");
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddDbContext<MyDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySqlConnectionString");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Register IUserService (IMPORTANT - must be before building the app)
builder.Services.AddScoped<UserAuthorService>();
builder.Services.AddScoped<RoleService>();


var app = builder.Build();

// Add CORS middleware (must be before routing/endpoints)
//connect to react <--
app.UseCors("_myAllowSpecificOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
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

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
