using SkynetBooking.Application.HumanResources.Commands;
using SkynetBooking.Application.Common.AppRequests;
using SkynetBooking.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace SkynetBooking.WebApi.Controllers;

[ApiController]
public class HumanResourcesController
{
    [HttpPost("api/human-resources")]
    public async Task<ActionResult<AppResponse<int>>> CreateHumanResource(
        [FromBody] CreateHumanResourceCommand command,
        [FromServices] CreateHumanResourceCommandHandler handler,
        [FromServices] CreateHumanResourceCommandValidator validator,
        CancellationToken cancellationToken)
    {
        var response = await handler.Handle(command, validator, cancellationToken);

        return response.ToActionResult();
    }
}
