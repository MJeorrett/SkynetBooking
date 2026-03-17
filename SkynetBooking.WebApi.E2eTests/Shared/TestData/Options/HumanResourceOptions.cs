using SkynetBooking.Core;

namespace SkynetBooking.WebApi.E2eTests.Shared.TestData.Options;

internal record HumanResourceOptions() : IEntityBuilderOptions<HumanResourceEntity>
{
    public HumanResourceEntity MapToEntity() => new();
}
