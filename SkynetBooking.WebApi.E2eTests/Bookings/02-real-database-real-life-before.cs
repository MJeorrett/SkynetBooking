using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using SkynetBooking.Application.Bookings.Commands;

namespace SkynetBooking.WebApi.E2eTests.Bookings;

/* SPEAKER NOTES:
- Spot what is unusal with the below test...
*/

public class Example2_Before
{
    [Fact]
    public async Task Should_Return200_When_EndIsAfterStart()
    {
        await using var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("E2eTests");
            });

        using var client = factory.CreateClient();

        var start = new DateTime(2025, 3, 16, 12, 0, 0);

        var request = new CreateBookingCommand
        {
            AiCustomerId = 123,
            HumanResourceId = 456,
            Start = start,
            End = start.AddHours(1)
        };

        var response = await client.PostAsJsonAsync("api/bookings", request);

        response.StatusCode.ShouldBe(HttpStatusCode.Created);
    }
}
