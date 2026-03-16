using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using SkynetBooking.Application.Bookings.Commands;
using SkynetBooking.Core;
using SkynetBooking.Infrastructure.Db;
using SkynetBooking.WebApi.E2eTests.Shared.WebApplicationFactory;

namespace SkynetBooking.WebApi.E2eTests.Bookings;

/* SPEAKER NOTES:
- Extract WAF and create fixture - Talk through
- Performance improvement - API takes a while to spin up.
- Central place to manage database resetting.
- Base class
  - For now:
    - ensures database is reset before each test.
    - HttpClient provided
  - More coming...
- Note: test is still quite verbose - will fix this...
*/

[Collection(CustomWebApplicationCollection.Name)]
public class Example3_After : TestBase
{
    public Example3_After(CustomWebApplicationFixture fixture) : base(fixture) { }

    [Fact]
    public async Task Should_Return400_When_EndIsBeforeStart()
    {
        int aiCustomerId;
        int humanResourceId;

        using (var scope = Factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<SkynetDbContext>();
            var aiCustomer = new AiCustomerEntity { FullName = "E2E Test Customer" };
            var humanResource = new HumanResourceEntity();
            context.AiCustomers.Add(aiCustomer);
            context.HumanResources.Add(humanResource);
            await context.SaveChangesAsync();

            aiCustomerId = aiCustomer.Id;
            humanResourceId = humanResource.Id;
        }

        var start = new DateTime(2025, 3, 16, 12, 0, 0);

        var request = new CreateBookingCommand
        {
            AiCustomerId = aiCustomerId,
            HumanResourceId = humanResourceId,
            Start = start,
            End = start.AddHours(-1)
        };

        var response = await HttpClient.PostAsJsonAsync("api/bookings", request);

        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
    }
}
