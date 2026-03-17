using SkynetBooking.Application.AiCustomers.Queries;
using SkynetBooking.WebApi.E2eTests.Shared.Endpoints.Base;

namespace SkynetBooking.WebApi.E2eTests.Shared.Endpoints;

internal static class AiCustomersEndpoints
{
    public static ListAiCustomersEndpoint ListAiCustomers(this HttpClient httpClient) => new(httpClient);
}

internal class ListAiCustomersEndpoint : ApiEndpointBase<List<AiCustomerDto>>
{
    public ListAiCustomersEndpoint(HttpClient httpClient) : base(httpClient)
    {
    }

    public override Task<HttpResponseMessage> Call()
    {
        return HttpClient.GetAsync("api/ai-customers");
    }
}
