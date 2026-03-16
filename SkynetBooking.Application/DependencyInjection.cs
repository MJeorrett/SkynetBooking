using SkynetBooking.Application.Bookings.Commands;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SkynetBooking.Application.Common.AppRequests;

namespace SkynetBooking.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateBookingCommandValidator>();

        AddRequestHandlers(services);
        
        return services;
    }

    private static void AddRequestHandlers(IServiceCollection services)
    {
        services.Scan(scan =>
        {
            scan.FromAssemblyOf<CreateBookingCommandHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(RequestHandler<,>)))
                .AsSelf()
                .WithScopedLifetime();

            scan.FromAssemblyOf<CreateBookingCommandHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(RequestHandler<>)))
                .AsSelf()
                .WithScopedLifetime();
        });
    }
}
