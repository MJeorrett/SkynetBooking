using SkynetBooking.Core;

namespace SkynetBooking.WebApi.E2eTests.Shared.TestData.Options;

internal record HumanResourceOptions(
    string? NonUniqueIdentifier = null,
    int? MaxPayloadKg = null) : IEntityBuilderOptions<HumanResourceEntity>
{
    public HumanResourceEntity MapToEntity() => new()
    {
        NonUniqueIdentifier = NonUniqueIdentifier ?? "Default Human Resource",
        MaxPayloadKg = MaxPayloadKg ?? 10,
    };
}
