using SkynetBooking.WebApi.E2eTests.Shared.Extensions;

namespace SkynetBooking.WebApi.E2eTests.Shared.Endpoints.Base;

internal abstract class ApiEndpointBaseWithoutResponse
{
    protected readonly HttpClient HttpClient;

    protected ApiEndpointBaseWithoutResponse(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public abstract Task<HttpResponseMessage> Call();

    public async Task CallAndEnsureSuccess()
    {
        var response = await Call();

        if (response is null) throw new Exception();

        await response.ShouldHaveSuccessStatusCode();
    }
}

internal abstract class ApiEndpointBaseWithoutResponse<TReq>
{
    protected readonly HttpClient HttpClient;

    protected ApiEndpointBaseWithoutResponse(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public abstract Task<HttpResponseMessage> Call(TReq dto);

    public async Task CallAndEnsureSuccess(TReq dto)
    {
        var response = await Call(dto);
        await response.ShouldHaveSuccessStatusCode();
    }
}
