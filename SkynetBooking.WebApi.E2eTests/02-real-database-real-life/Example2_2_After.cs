//using System.Net;
//using System.Net.Http.Json;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.Extensions.DependencyInjection;
//using Shouldly;
//using SkynetBooking.Application.Bookings.Commands;
//using SkynetBooking.Core;
//using SkynetBooking.Infrastructure.Db;

//namespace SkynetBooking.WebApi.E2eTests.Bookings;

//public class Example2_After
//{
//    [Fact]
//    public async Task Should_Return200_When_EndIsAfterStart()
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
//            var context = scope.ServiceProvider.GetRequiredService<SkynetDbContext>();
//            var aiCustomer = new AiCustomerEntity { FullName = "E2E Test Customer", SerialNumber = "abc123" };
//            var humanResource = new HumanResourceEntity() { MaxPayloadKg = 123, NonUniqueIdentifier = "Sam Blog" };
//            context.AiCustomers.Add(aiCustomer);
//            context.HumanResources.Add(humanResource);
//            await context.SaveChangesAsync();

//            aiCustomerId = aiCustomer.Id;
//            humanResourceId = humanResource.Id;
//        }

//        using var client = factory.CreateClient();

//        var start = new DateTime(2025, 3, 16, 12, 0, 0);

//        var request = new CreateBookingCommand
//        {
//            AiCustomerId = aiCustomerId,
//            HumanResourceId = humanResourceId,
//            Start = start,
//            End = start.AddHours(1)
//        };

//        var response = await client.PostAsJsonAsync("api/bookings", request);

//        response.StatusCode.ShouldBe(HttpStatusCode.Created);
//    }
//}
