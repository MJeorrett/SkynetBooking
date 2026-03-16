using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SkynetBooking.Infrastructure.Db;

namespace SkynetBooking.WebApi.E2eTests.Shared.WebApplicationFactory;

public class CustomWebApplicationFixture
{
    public CustomWebApplicationFactory Factory { get; } = new();

    public CustomWebApplicationFixture()
    {
        var services = Factory.Services.CreateScope().ServiceProvider;
        EnsureDatabaseCreatedAndMigrated(services);
    }

    private static void EnsureDatabaseCreatedAndMigrated(IServiceProvider services)
    {
        var logger = services.GetRequiredService<ILogger<CustomWebApplicationFixture>>();

        try
        {
            logger.LogInformation("Migrating database.");
            var dbContext = services.GetRequiredService<SkynetDbContext>();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.Migrate();
            logger.LogInformation("Database migration complete.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to ensure database is created and migrated.");
            throw;
        }
    }
}
