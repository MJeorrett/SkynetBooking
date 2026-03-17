using Microsoft.EntityFrameworkCore;
using Shouldly;
using SkynetBooking.WebApi.E2eTests.Shared.Dtos.Bookings;
using SkynetBooking.WebApi.E2eTests.Shared.Endpoints;
using SkynetBooking.WebApi.E2eTests.Shared.WebApplicationFactory;

namespace SkynetBooking.WebApi.E2eTests.Bookings;

[Collection(CustomWebApplicationCollection.Name)]
public class Example4_CreateBooking : TestBase
{
    public Example4_CreateBooking(CustomWebApplicationFixture fixture) : base(fixture) { }

    [Fact]
    public async Task Should_CreateBooking_When_AiCustomerAndHumanResourceExist_Before()
    {
        const string seededAiCustomerName = "Sir Botsalot";

        var db = ResolveDbContext();
        var aiCustomer = await db.AiCustomers
            .FirstOrDefaultAsync(c => c.FullName == seededAiCustomerName);
        aiCustomer.ShouldNotBeNull();

        var humanResourceId = await db.HumanResources
            .OrderBy(h => h.Id)
            .Select(h => h.Id)
            .FirstAsync();

        var createRequest = new CreateBookingRequestDto
        {
            AiCustomerId = aiCustomer.Id,
            HumanResourceId = humanResourceId,
            Start = DateTime.UtcNow.Date.AddHours(10),
            End = DateTime.UtcNow.Date.AddHours(11),
        };

        var bookingId = await HttpClient.CreateBooking().CallAndParseResponse(createRequest);

        bookingId.ShouldBeGreaterThan(0);
    }

    // [Fact]
    // public async Task Should_CreateBooking_When_AiCustomerAndHumanResourceExist_After()
    // {
    //     var aiCustomerId = await CreateAiCustomer();
    //     var humanResourceId = await CreateHumanResource();

    //     var createRequest = new CreateBookingRequestDto
    //     {
    //         AiCustomerId = aiCustomerId,
    //         HumanResourceId = humanResourceId,
    //         Start = DateTime.UtcNow.Date.AddHours(10),
    //         End = DateTime.UtcNow.Date.AddHours(11),
    //     };

    //     var bookingId = await HttpClient.CreateBooking().CallAndParseResponse(createRequest);

    //     bookingId.ShouldBeGreaterThan(0);
    // }
}
