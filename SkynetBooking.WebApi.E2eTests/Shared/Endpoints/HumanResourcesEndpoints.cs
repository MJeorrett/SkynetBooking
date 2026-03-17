using System.Net.Http.Json;
using SkynetBooking.WebApi.E2eTests.Shared.Dtos.HumanResources;
using SkynetBooking.WebApi.E2eTests.Shared.Endpoints.Base;

namespace SkynetBooking.WebApi.E2eTests.Shared.Endpoints;

internal static class HumanResourcesEndpoints
{
    public static CreateHumanResourceEndpoint CreateHumanResource(this HttpClient httpClient) => new(httpClient);
}

internal class CreateHumanResourceEndpoint : ApiEndpointBase<CreateHumanResourceRequestDto, int>
{
    public CreateHumanResourceEndpoint(HttpClient httpClient) : base(httpClient)
    {
    }

    public override Task<HttpResponseMessage> Call(CreateHumanResourceRequestDto dto)
    {
        return HttpClient.PostAsJsonAsync("api/human-resources", dto);
    }
}
