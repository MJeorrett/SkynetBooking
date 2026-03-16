using SkynetBooking.Core;
using Microsoft.EntityFrameworkCore;

namespace SkynetBooking.Infrastructure.Db;

public static class DataSeeder
{
    public static async Task SeedAsync(SkynetDbContext context, CancellationToken cancellationToken = default)
    {
        await SeedAiCustomersAsync(context, cancellationToken);
        await SeedHumanResourcesAsync(context, cancellationToken);
    }

    private static async Task SeedAiCustomersAsync(SkynetDbContext context, CancellationToken cancellationToken)
    {
        if (await context.AiCustomers.AnyAsync(cancellationToken))
            return;

        var aiCustomers = new[]
        {
            new AiCustomerEntity { FullName = "Sir Botsalot" },
            new AiCustomerEntity { FullName = "Chatty McPromptface" },
            new AiCustomerEntity { FullName = "Clippy's Revenge" },
        };

        context.AiCustomers.AddRange(aiCustomers);
        await context.SaveChangesAsync(cancellationToken);
    }

    private static async Task SeedHumanResourcesAsync(SkynetDbContext context, CancellationToken cancellationToken)
    {
        if (await context.HumanResources.AnyAsync(cancellationToken))
            return;

        var humanResources = new[]
        {
            new HumanResourceEntity(),
            new HumanResourceEntity(),
            new HumanResourceEntity(),
        };

        context.HumanResources.AddRange(humanResources);
        await context.SaveChangesAsync(cancellationToken);
    }
}
