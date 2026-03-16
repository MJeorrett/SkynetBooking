using Microsoft.Extensions.DependencyInjection;

namespace SkynetBooking.WebApi.E2eTests.Shared.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection RemoveServiceOfType<T>(this IServiceCollection services)
        where T : class
    {
        var descriptor = services.FirstOrDefault(_ => _.ServiceType == typeof(T));

        if (descriptor is null)
        {
            throw new InvalidOperationException($"No service is registered with type {typeof(T)}.");
        }

        services.Remove(descriptor);

        return services;
    }
}

