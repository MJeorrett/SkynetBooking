//using System.Net;
//using System.Net.Http.Json;
//using Shouldly;
//using SkynetBooking.Application.AiCustomers.Queries;
//using SkynetBooking.Application.Common.AppRequests;
//using SkynetBooking.WebApi.E2eTests.Shared.WebApplicationFactory;

//namespace SkynetBooking.WebApi.E2eTests.Bookings;

//[Collection(CustomWebApplicationCollection.Name)]
//public class Example4_AiCustomers : TestBase
//{
//   public Example4_AiCustomers(CustomWebApplicationFixture fixture) : base(fixture) { }

//   [Fact]
//   public async Task Should_ReturnEmptyList_When_NoAiCustomers()
//   {
//       var response = await HttpClient.GetAsync("/api/ai-customers");

//       response.StatusCode.ShouldBe(HttpStatusCode.OK);

//       var appResponse = await response.Content.ReadFromJsonAsync<AppResponse<List<AiCustomerDto>>>();

//       appResponse.ShouldNotBeNull();
//       appResponse.Content.ShouldBeEmpty();
//   }
//}
