using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using Respawn.Graph;
using SkynetBooking.Infrastructure.Db;

namespace SkynetBooking.WebApi.E2eTests.Shared.WebApplicationFactory;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private Respawner? _respawner;

    public async Task ResetState()
    {
        var services = GetScopedServiceProvider();
        var configuration = services.GetRequiredService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("SqlServer")
            ?? throw new InvalidOperationException("Connection string 'SqlServer' is not configured.");

        await ResetDatabaseAsync(connectionString);

        var dbContext = services.GetRequiredService<SkynetDbContext>();
        await DataSeeder.SeedAsync(dbContext);
    }

    private async Task ResetDatabaseAsync(string connectionString)
    {
        _respawner ??= await Respawner.CreateAsync(connectionString, new RespawnerOptions
        {
            TablesToIgnore =
            [
                new Table("__EFMigrationsHistory"),
            ],
        });

        await _respawner.ResetAsync(connectionString);
    }

    public IServiceProvider GetScopedServiceProvider() => Services.CreateScope().ServiceProvider;

    public T GetRequiredScopedService<T>() where T : notnull =>
        GetScopedServiceProvider().GetRequiredService<T>();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("E2eTests");
        base.ConfigureWebHost(builder);
    }
}
