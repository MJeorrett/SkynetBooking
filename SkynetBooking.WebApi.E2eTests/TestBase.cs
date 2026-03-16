using SkynetBooking.WebApi.E2eTests.Shared.WebApplicationFactory;

namespace SkynetBooking.WebApi.E2eTests;

public class TestBase : IAsyncLifetime
{
    protected readonly CustomWebApplicationFactory Factory;
    protected readonly CustomWebApplicationFixture Fixture;
    protected readonly IServiceProvider Services;
    protected readonly HttpClient HttpClient;

    public TestBase(CustomWebApplicationFixture fixture)
    {
        Fixture = fixture;
        Factory = fixture.Factory;
        Services = Factory.GetScopedServiceProvider();
        HttpClient = Factory.CreateClient();
    }

    public virtual async Task InitializeAsync() => await Factory.ResetState();

    public virtual Task DisposeAsync() => Task.CompletedTask;
}
