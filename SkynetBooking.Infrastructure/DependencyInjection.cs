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
        IConfiguration config)
    {
        AddPersistence(services, config);

        return services;
    }

    private static void AddPersistence(
        IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<SkynetDbContext>(options =>
            options.UseSqlServer(
                config.GetConnectionString("SqlServer"),
                builder => builder.MigrationsAssembly(typeof(SkynetDbContext).Assembly.FullName)));

        services.AddScoped<ISkynetDbContext>(provider => provider.GetRequiredService<SkynetDbContext>());
    }
}
