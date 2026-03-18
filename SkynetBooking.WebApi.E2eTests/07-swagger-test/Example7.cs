//using SkynetBooking.WebApi.E2eTests.Shared.Extensions;
//using SkynetBooking.WebApi.E2eTests.Shared.WebApplicationFactory;
//using System.Net;

//namespace SkynetBooking.WebApi.E2eTests.Bookings;

//[Collection(CustomWebApplicationCollection.Name)]
//public class SwaggerTests : TestBase
//{
//    public SwaggerTests(
//        CustomWebApplicationFixture webApplicationFixture) :
//        base(webApplicationFixture)
//    {
//    }

//    [Fact]
//    public async Task SwaggerJson_Should_LoadSuccessfully()
//    {
//        var response = await HttpClient.GetAsync("swagger/v1/swagger.json");

//        await response.ShouldHaveStatusCode(HttpStatusCode.OK);
//    }
//}

