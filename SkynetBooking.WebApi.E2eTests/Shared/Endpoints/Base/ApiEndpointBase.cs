using SkynetBooking.WebApi.E2eTests.Shared.Extensions;

namespace SkynetBooking.WebApi.E2eTests.Shared.Endpoints.Base;

internal abstract class ApiEndpointBase<TResponse> : ApiEndpointBaseWithoutResponse
{
    protected ApiEndpointBase(HttpClient httpClient) :
        base(httpClient)
    {
    }

    public async Task<TResponse> CallAndParseResponse()
    {
        var response = await Call();
        await response.ShouldHaveSuccessStatusCode();

        var content = await response.ReadAppResponseContentAs<TResponse>();

        return content;
    }
}

internal abstract class ApiEndpointBase<TDto, TResponse> : ApiEndpointBaseWithoutResponse<TDto>
{
    protected ApiEndpointBase(HttpClient httpClient) :
        base(httpClient)
    {
    }

    public async Task<TResponse> CallAndParseResponse(TDto dto)
    {
        var response = await Call(dto);
        await response.ShouldHaveSuccessStatusCode();

        var content = await response.ReadAppResponseContentAs<TResponse>();

        return content;
    }

    public async Task<TResponse> CallAndParseBareResponse(TDto dto)
    {
        var response = await Call(dto);
        await response.ShouldHaveSuccessStatusCode();

        var content = await response.ReadResponseContentAs<TResponse>();

        return content;
    }
}
