using SkynetBooking.Application;
using SkynetBooking.Infrastructure;
using SkynetBooking.Infrastructure.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment.EnvironmentName);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Ensure database is migrated and seeded (Development only)
// if (app.Environment.IsDevelopment())
// {
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<SkynetDbContext>();
    await DataSeeder.SeedAsync(context);
// }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }