using Microsoft.Extensions.DependencyInjection;
using SkynetBooking.Core;
using SkynetBooking.Infrastructure.Db;
using SkynetBooking.WebApi.E2eTests.Shared.TestData.Options;
using SkynetBooking.WebApi.E2eTests.Shared.WebApplicationFactory;

namespace SkynetBooking.WebApi.E2eTests;

public class TestBase : IAsyncLifetime
{
    protected readonly CustomWebApplicationFactory Factory;
    protected readonly CustomWebApplicationFixture Fixture;
    protected readonly IServiceProvider Services;
    protected readonly HttpClient HttpClient;

    protected SkynetDbContext ResolveDbContext() => Services.GetRequiredService<SkynetDbContext>();

    public TestBase(CustomWebApplicationFixture fixture)
    {
        Fixture = fixture;
        Factory = fixture.Factory;
        Services = Factory.GetScopedServiceProvider();
        HttpClient = Factory.CreateClient();
    }

    private async Task<int> CreateEntity<T>(IEntityBuilderOptions<T> entityOptions) where T : class, IEntityBase
    {
        var entity = entityOptions.MapToEntity();

        var dbContext = ResolveDbContext();
        dbContext.Set<T>().Add(entity);

        await dbContext.SaveChangesAsync(default);

        return entity.Id;
    }

    internal async Task<int> CreateAiCustomer(AiCustomerOptions? options = null) => await CreateEntity(options ?? new());

    internal async Task<int> CreateHumanResource(HumanResourceOptions? options = null) => await CreateEntity(options ?? new());

    public virtual async Task InitializeAsync() => await Factory.ResetState();

    public virtual Task DisposeAsync() => Task.CompletedTask;
}
