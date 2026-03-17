//using System.Net;
//using Microsoft.EntityFrameworkCore;
//using Shouldly;
//using SkynetBooking.Core;
//using SkynetBooking.WebApi.E2eTests.Shared.Dtos.Bookings;
//using SkynetBooking.WebApi.E2eTests.Shared.Endpoints;
//using SkynetBooking.WebApi.E2eTests.Shared.WebApplicationFactory;

//namespace SkynetBooking.WebApi.E2eTests.Bookings;

//[Collection(CustomWebApplicationCollection.Name)]
//public class Example4_CreateBooking : TestBase
//{
//    public Example4_CreateBooking(CustomWebApplicationFixture fixture) : base(fixture) { }

//    [Fact]
//    public async Task Should_CreateBooking_When_AiCustomerAndHumanResourceExist_Before()
//    {
//        const string seededAiCustomerName = "Sir Botsalot";

//        var db = ResolveDbContext();
//        var aiCustomer = await db.AiCustomers
//            .FirstOrDefaultAsync(c => c.FullName == seededAiCustomerName);
//        aiCustomer.ShouldNotBeNull();

//        var humanResourceId = await db.HumanResources
//            .OrderBy(h => h.Id)
//            .Select(h => h.Id)
//            .FirstAsync();

//        var createRequest = new CreateBookingRequestDto
//        {
//            AiCustomerId = aiCustomer.Id,
//            HumanResourceId = humanResourceId,
//            Start = DateTime.UtcNow.Date.AddHours(10),
//            End = DateTime.UtcNow.Date.AddHours(11),
//        };

//        var response = await HttpClient.CreateBooking().Call(createRequest);

//        response.StatusCode.ShouldBe(HttpStatusCode.Created);
//    }

//    [Fact]
//    public async Task Should_CreateBooking_When_AiCustomerAndHumanResourceExist_AfterStep1()
//    {
//        var db = ResolveDbContext();

//        var aiCustomer = new AiCustomerEntity
//        {
//            FullName = "DB-created AI Customer",
//            SerialNumber = "SN-000001",
//        };
//        db.AiCustomers.Add(aiCustomer);

//        var humanResource = new HumanResourceEntity();
//        db.HumanResources.Add(humanResource);

//        await db.SaveChangesAsync();

//        var createRequest = new CreateBookingRequestDto
//        {
//            AiCustomerId = aiCustomer.Id,
//            HumanResourceId = humanResource.Id,
//            Start = DateTime.UtcNow.Date.AddHours(10),
//            End = DateTime.UtcNow.Date.AddHours(11),
//        };

//        var bookingId = await HttpClient.CreateBooking().CallAndParseResponse(createRequest);

//        bookingId.ShouldBeGreaterThan(0);
//    }

//    [Fact]
//    public async Task Should_CreateBooking_When_AiCustomerAndHumanResourceExist_AfterStep2()
//    {
//        var aiCustomerId = await CreateAiCustomer();
//        var humanResourceId = await CreateHumanResource();

//        var createRequest = new CreateBookingRequestDto
//        {
//            AiCustomerId = aiCustomerId,
//            HumanResourceId = humanResourceId,
//            Start = DateTime.UtcNow.Date.AddHours(10),
//            End = DateTime.UtcNow.Date.AddHours(11),
//        };

//        var bookingId = await HttpClient.CreateBooking().CallAndParseResponse(createRequest);

//        bookingId.ShouldBeGreaterThan(0);
//    }
//}
