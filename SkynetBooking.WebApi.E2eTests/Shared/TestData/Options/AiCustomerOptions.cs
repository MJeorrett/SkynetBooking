using SkynetBooking.Core;

namespace SkynetBooking.WebApi.E2eTests.Shared.TestData.Options;

internal record AiCustomerOptions(
    string? FullName = null,
    string? SerialNumber = null) : IEntityBuilderOptions<AiCustomerEntity>
{
    private static int _defaultSerialNumberIndex = 0;

    public AiCustomerEntity MapToEntity()
    {
        return new()
        {
            FullName = FullName ?? $"Default AI Customer Name",
            SerialNumber = SerialNumber ?? $"SN-{Interlocked.Increment(ref _defaultSerialNumberIndex):D6}",
        };
    }
}
