using SkynetBooking.WebApi.E2eTests.Shared.Extensions;

namespace SkynetBooking.WebApi.E2eTests.Shared.Endpoints.Base;

internal abstract class ApiEndpointBase<TRes> : ApiEndpointBaseWithoutResponse
{
    protected ApiEndpointBase(HttpClient httpClient) :
        base(httpClient)
    {
    }

    public async Task<TRes> CallAndParseResponse()
    {
        var response = await Call();
        await response.ShouldHaveSuccessStatusCode();

        var content = await response.ReadAppResponseContentAs<TRes>();

        return content;
    }

    public async Task<TRes> CallAndParseBareResponse()
    {
        var response = await Call();
        await response.ShouldHaveSuccessStatusCode();

        var content = await response.ReadResponseContentAs<TRes>();

        return content;
    }
}

internal abstract class ApiEndpointBase<TReq, TRes> : ApiEndpointBaseWithoutResponse<TReq>
{
    protected ApiEndpointBase(HttpClient httpClient) :
        base(httpClient)
    {
    }

    public async Task<TRes> CallAndParseResponse(TReq dto)
    {
        var response = await Call(dto);
        await response.ShouldHaveSuccessStatusCode();

        var content = await response.ReadAppResponseContentAs<TRes>();

        return content;
    }

    public async Task<TRes> CallAndParseBareResponse(TReq dto)
    {
        var response = await Call(dto);
        await response.ShouldHaveSuccessStatusCode();

        var content = await response.ReadResponseContentAs<TRes>();

        return content;
    }
}
