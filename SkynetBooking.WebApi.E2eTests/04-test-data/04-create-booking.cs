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
//    public async Task Should_CreateBooking_When_AiCustomerAndHumanResourceExist_Before_UsingSeeding()
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
//            Start = new DateTime(2027, 3, 17, 10, 0, 0),
//            End = new DateTime(2027, 3, 17, 11, 0, 0),
//        };

//        var response = await HttpClient.CreateBooking().Call(createRequest);

//        response.StatusCode.ShouldBe(HttpStatusCode.Created);
//    }

//    [Fact]
//    public async Task Should_CreateBooking_When_AiCustomerAndHumanResourceExist_After_ManualSetUp()
//    {
//        var db = ResolveDbContext();

//        var aiCustomer = new AiCustomerEntity
//        {
//            FullName = "DB-created AI Customer",
//            SerialNumber = "SN-000001",
//        };
//        db.AiCustomers.Add(aiCustomer);

//        var humanResource = new HumanResourceEntity() { NonUniqueIdentifier = "Sam Stevens", MaxPayloadKg = 61 };
//        db.HumanResources.Add(humanResource);

//        await db.SaveChangesAsync();

//        var createRequest = new CreateBookingRequestDto
//        {
//            AiCustomerId = aiCustomer.Id,
//            HumanResourceId = humanResource.Id,
//            Start = new DateTime(2027, 3, 17, 10, 0, 0),
//            End = new DateTime(2027, 3, 17, 11, 0, 0),
//        };

//        var response = await HttpClient.CreateBooking().Call(createRequest);

//        response.StatusCode.ShouldBe(HttpStatusCode.Created);
//    }

//    [Fact]
//    public async Task Should_CreateBooking_When_AiCustomerAndHumanResourceExist_After_TestData()
//    {
//        var aiCustomerId = await CreateAiCustomer();
//        var humanResourceId = await CreateHumanResource();

//        var createRequest = new CreateBookingRequestDto
//        {
//            AiCustomerId = aiCustomerId,
//            HumanResourceId = humanResourceId,
//            Start = new DateTime(2027, 3, 17, 10, 0, 0),
//            End = new DateTime(2027, 3, 17, 11, 0, 0),
//        };

//        var response = await HttpClient.CreateBooking().Call(createRequest);

//        response.StatusCode.ShouldBe(HttpStatusCode.Created);
//    }
//}
