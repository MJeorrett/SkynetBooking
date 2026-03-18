using SkynetBooking.Application.Bookings.Commands;
using SkynetBooking.Application.Bookings.Queries;
using SkynetBooking.Application.Common.AppRequests;
using SkynetBooking.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace SkynetBooking.WebApi.Controllers;

[ApiController]
public class BookingsController
{
    [HttpGet("api/bookings")]
    public async Task<ActionResult<AppResponse<List<BookingSummaryDto>>>> ListBookings(
        [FromServices] ListBookingsQueryHandler handler,
        CancellationToken cancellationToken)
    {
        var response = await handler.Handle(new ListBookingsQuery(), cancellationToken);

        return response.ToActionResult();
    }

    [HttpPost("api/bookings")]
    public async Task<ActionResult<AppResponse<int>>> CreateBooking(
        [FromBody] CreateBookingCommand command,
        [FromServices] CreateBookingCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var response = await handler.Handle(command,cancellationToken);

        return response.ToActionResult();
    }
}
