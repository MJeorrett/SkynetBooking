//using System.Net;
//using Shouldly;
//using SkynetBooking.WebApi.E2eTests.Shared.Endpoints;
//using SkynetBooking.WebApi.E2eTests.Shared.WebApplicationFactory;

//namespace SkynetBooking.WebApi.E2eTests.Bookings;

//[Collection(CustomWebApplicationCollection.Name)]
//public class Example6 : TestBase
//{
//    public Example6(CustomWebApplicationFixture fixture) : base(fixture) { }

//    [Fact]
//    public async Task Should_CreateTwoHumans_WithSameNonUniqueIdentifier()
//    {
//        var response1 = await HttpClient.CreateHumanResource().Call(new()
//        {
//            NonUniqueIdentifier = "Rich Russel",
//            MaxPayloadKg = 9,
//        });
//        response1.StatusCode.ShouldBe(HttpStatusCode.Created);

//        var response2 = await HttpClient.CreateHumanResource().Call(new()
//        {
//            NonUniqueIdentifier = "Rich Russel",
//            MaxPayloadKg = 18,
//        });
//        response2.StatusCode.ShouldBe(HttpStatusCode.Created);
//    }
//}
