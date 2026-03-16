using SkynetBooking.Application.Bookings.Commands;
using SkynetBooking.Application.Common.AppRequests;
using SkynetBooking.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace SkynetBooking.WebApi.Controllers;

[ApiController]
public class BookingsController
{
    [HttpPost("api/bookings")]
    public async Task<ActionResult<AppResponse<int>>> CreateBooking(
        [FromBody] CreateBookingCommand command,
        [FromServices] CreateBookingCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var response = await handler.Handle(command, cancellationToken);

        return response.ToActionResult();
    }
}
