//using Shouldly;
//using SkynetBooking.WebApi.E2eTests.Shared.Dtos.Bookings;
//using SkynetBooking.WebApi.E2eTests.Shared.Endpoints;
//using SkynetBooking.WebApi.E2eTests.Shared.WebApplicationFactory;

//namespace SkynetBooking.WebApi.E2eTests.Bookings;

//[Collection(CustomWebApplicationCollection.Name)]
//public class Example9_EndResult_After : TestBase
//{
//    public Example8_EndResult_After(CustomWebApplicationFixture fixture) : base(fixture)
//    {
//    }

//    [Fact]
//    public async Task Should_CreateBooking_Then_ListBookings_And_SeeItReturned_After()
//    {
//        var aiCustomerId = await CreateAiCustomer();
//        var humanResourceId = await CreateHumanResource();

//        var start = new DateTime(2027, 3, 17, 10, 0, 0, DateTimeKind.Utc);

//        var createRequest = new CreateBookingRequestDto
//        {
//            AiCustomerId = aiCustomerId,
//            HumanResourceId = humanResourceId,
//            Start = start,
//            End = start.AddHours(1),
//        };

//        var bookingId = await HttpClient.CreateBooking().CallAndParseResponse(createRequest);

//        var bookings = await HttpClient.ListBookings().CallAndParseResponse();

//        bookings.Any(b => b.Id == bookingId).ShouldBeTrue();
//    }
//}

