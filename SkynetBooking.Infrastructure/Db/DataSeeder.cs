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
            new AiCustomerEntity { FullName = "Sir Botsalot", SerialNumber = "123" },
            new AiCustomerEntity { FullName = "Chatty McPromptface", SerialNumber = "abc" },
            new AiCustomerEntity { FullName = "Clippy's Revenge", SerialNumber = "zz1" },
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
            new HumanResourceEntity() { NonUniqueIdentifier = "Sarah Royston", MaxPayloadKg = 92 },
            new HumanResourceEntity() { NonUniqueIdentifier = "Chris Mitchel", MaxPayloadKg = 87 },
            new HumanResourceEntity() { NonUniqueIdentifier = "Big Mike", MaxPayloadKg = 120 },
        };

        context.HumanResources.AddRange(humanResources);
        await context.SaveChangesAsync(cancellationToken);
    }
}
