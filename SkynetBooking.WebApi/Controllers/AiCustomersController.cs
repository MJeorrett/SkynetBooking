using SkynetBooking.Application.AiCustomers.Queries;
using SkynetBooking.Application.Common.AppRequests;
using SkynetBooking.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace SkynetBooking.WebApi.Controllers;

[ApiController]
public class AiCustomersController
{
    [HttpGet("api/ai-customers")]
    public async Task<ActionResult<AppResponse<List<AiCustomerDto>>>> ListAiCustomers(
        [FromServices] ListAiCustomersQueryHandler handler,
        CancellationToken cancellationToken)
    {
        var response = await handler.Handle(new ListAiCustomersQuery(), cancellationToken);

        return response.ToActionResult();
    }
}
