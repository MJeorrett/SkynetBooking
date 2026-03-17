// using System.Net;
// using System.Net.Http.Json;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Shouldly;
// using SkynetBooking.Application.Bookings.Commands;
// using SkynetBooking.Core;
// using SkynetBooking.Infrastructure.Db;
// using SkynetBooking.WebApi.E2eTests.Shared.WebApplicationFactory;

// namespace SkynetBooking.WebApi.E2eTests.Bookings;

// public class Example3_Before
// {
//    [Fact]
//    public async Task Should_Return400_When_EndIsBeforeStart()
//    {
//        // BEGIN Boiler plate
//        var factory = new CustomWebApplicationFactory();

//        using (var scope = factory.Services.CreateScope())
//        {
//            var context = scope.ServiceProvider.GetRequiredService<SkynetDbContext>();
//            context.Database.EnsureDeleted();
//            context.Database.Migrate();
//        }

//        await factory.ResetState();

//        var client = factory.CreateClient();
//        // END Boiler plate

//        int aiCustomerId;
//        int humanResourceId;

//        using (var scope = factory.Services.CreateScope())
//        {
//            var context = scope.ServiceProvider.GetRequiredService<SkynetDbContext>();
//            var aiCustomer = new AiCustomerEntity { FullName = "E2E Test Customer", SerialNumber = "123abc" };
//            var humanResource = new HumanResourceEntity();
//            context.AiCustomers.Add(aiCustomer);
//            context.HumanResources.Add(humanResource);
//            await context.SaveChangesAsync();

//            aiCustomerId = aiCustomer.Id;
//            humanResourceId = humanResource.Id;
//        }

//        var start = new DateTime(2025, 3, 16, 12, 0, 0);

//        var request = new CreateBookingCommand
//        {
//            AiCustomerId = aiCustomerId,
//            HumanResourceId = humanResourceId,
//            Start = start,
//            End = start.AddHours(-1)
//        };

//        var response = await client.PostAsJsonAsync("api/bookings", request);

//        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
//    }
// }
