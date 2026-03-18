//using System.Net.Http.Json;
//using Shouldly;
//using SkynetBooking.Application.AiCustomers.Queries;
//using SkynetBooking.Application.Common.AppRequests;
//using SkynetBooking.WebApi.E2eTests.Shared.Endpoints;
//using SkynetBooking.WebApi.E2eTests.Shared.TestData.Options;
//using SkynetBooking.WebApi.E2eTests.Shared.WebApplicationFactory;

//namespace SkynetBooking.WebApi.E2eTests.BreakingChangeDetection;

//[Collection(CustomWebApplicationCollection.Name)]
//public class Example8_1_Before : TestBase
//{
//    public Example8_1_Before(CustomWebApplicationFixture fixture) : base(fixture)
//    {
//    }

//    [Fact]
//    public async Task Should_ListAiCustomers_IncludingCreatedCustomer_Before()
//    {
//        var aiCustomerId = await CreateAiCustomer(new AiCustomerOptions(
//            FullName: "C3PO",
//            SerialNumber: "SN-08-1123"));

//        var response = await HttpClient.ListAiCustomers().Call();

//        var actual = await response.Content.ReadFromJsonAsync<AppResponse<List<AiCustomerDto>>>();
//        actual.ShouldNotBeNull();
//        actual.Content.ShouldNotBeNull();
//        actual.Content!.Count.ShouldBe(1);
//        actual.Content![0].FullName.ShouldBe("C3PO");
//    }
//}
