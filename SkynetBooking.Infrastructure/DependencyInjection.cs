using SkynetBooking.Application.Common.Interfaces;
using SkynetBooking.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SkynetBooking.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config,
        string? environmentName = null)
    {
        var env = environmentName ?? config["ASPNETCORE_ENVIRONMENT"] ?? string.Empty;
        AddPersistence(services, config, env);

        return services;
    }

    private static void AddPersistence(
        IServiceCollection services,
        IConfiguration config,
        string environmentName)
    {
        if (string.Equals(environmentName, "E2eTests", StringComparison.OrdinalIgnoreCase))
        {
            services.AddDbContext<SkynetDbContext>(options =>
                options.UseInMemoryDatabase("SkynetBooking.E2eTests"));
        }
        else
        {
            services.AddDbContext<SkynetDbContext>(options =>
                options.UseSqlServer(
                    config.GetConnectionString("SqlServer"),
                    builder => builder.MigrationsAssembly(typeof(SkynetDbContext).Assembly.FullName)));
        }

        services.AddScoped<ISkynetDbContext>(provider => provider.GetRequiredService<SkynetDbContext>());
    }
}
