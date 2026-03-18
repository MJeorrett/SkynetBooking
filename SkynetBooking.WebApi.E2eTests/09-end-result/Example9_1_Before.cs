//using System.Net;
//using System.Net.Http.Json;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.Extensions.DependencyInjection;
//using Shouldly;
//using SkynetBooking.Application.Bookings.Commands;
//using SkynetBooking.Application.Bookings.Queries;
//using SkynetBooking.Application.Common.AppRequests;
//using SkynetBooking.Core;
//using SkynetBooking.Infrastructure.Db;

//namespace SkynetBooking.WebApi.E2eTests.Bookings;

//public class Example9_EndResult_Before
//{
//    [Fact]
//    public async Task Should_CreateBooking_Then_ListBookings_And_SeeItReturned_Before()
//    {
//        await using var factory = new WebApplicationFactory<Program>()
//            .WithWebHostBuilder(builder =>
//            {
//                builder.UseEnvironment("E2eTests");
//            });

//        int aiCustomerId;
//        int humanResourceId;

//        using (var scope = factory.Services.CreateScope())
//        {
//            var db = scope.ServiceProvider.GetRequiredService<SkynetDbContext>();

//            var aiCustomer = new AiCustomerEntity { FullName = "E2E Test Customer", SerialNumber = "SN-08-BEFORE" };
//            var humanResource = new HumanResourceEntity { NonUniqueIdentifier = "E2E Test Human Resource" };

//            db.AiCustomers.Add(aiCustomer);
//            db.HumanResources.Add(humanResource);
//            await db.SaveChangesAsync();

//            aiCustomerId = aiCustomer.Id;
//            humanResourceId = humanResource.Id;
//        }

//        using var client = factory.CreateClient();

//        var start = new DateTime(2027, 3, 17, 10, 0, 0, DateTimeKind.Utc);

//        var createRequest = new CreateBookingCommand
//        {
//            AiCustomerId = aiCustomerId,
//            HumanResourceId = humanResourceId,
//            Start = start,
//            End = start.AddHours(1),
//        };

//        var createResponse = await client.PostAsJsonAsync("api/bookings", createRequest);
//        createResponse.StatusCode.ShouldBe(HttpStatusCode.Created);

//        var created = await createResponse.Content.ReadFromJsonAsync<AppResponse<int>>();
//        created.ShouldNotBeNull();
//        var bookingId = created.Content;
//        bookingId.ShouldBeGreaterThan(0);

//        var listResponse = await client.GetAsync("api/bookings");
//        listResponse.StatusCode.ShouldBe(HttpStatusCode.OK);

//        var list = await listResponse.Content.ReadFromJsonAsync<AppResponse<List<BookingSummaryDto>>>();
//        list.ShouldNotBeNull();
//        list.Content.ShouldNotBeNull();

//        list.Content.Any(b => b.Id == bookingId).ShouldBeTrue();
//    }
//}
