using System.Net.Http.Json;
using SkynetBooking.Application.Bookings.Queries;
using SkynetBooking.WebApi.E2eTests.Shared.Dtos.Bookings;
using SkynetBooking.WebApi.E2eTests.Shared.Endpoints.Base;

namespace SkynetBooking.WebApi.E2eTests.Shared.Endpoints;

internal static class BookingsEndpoints
{
    public static CreateBookingEndpoint CreateBooking(this HttpClient httpClient) => new(httpClient);
    public static ListBookingsEndpoint ListBookings(this HttpClient httpClient) => new(httpClient);
}

internal class CreateBookingEndpoint : ApiEndpointBase<CreateBookingRequestDto, int>
{
    public CreateBookingEndpoint(HttpClient httpClient) : base(httpClient)
    {
    }

    public override Task<HttpResponseMessage> Call(CreateBookingRequestDto dto)
    {
        return HttpClient.PostAsJsonAsync("api/bookings", dto);
    }
}

internal class ListBookingsEndpoint : ApiEndpointBase<List<BookingSummaryDto>>
{
    public ListBookingsEndpoint(HttpClient httpClient) : base(httpClient)
    {
    }

    public override Task<HttpResponseMessage> Call()
    {
        return HttpClient.GetAsync("api/bookings");
    }
}
