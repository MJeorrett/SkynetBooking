using SkynetBooking.Application.Common.Interfaces;
using SkynetBooking.Application.Common.AppRequests;
using Microsoft.EntityFrameworkCore;

namespace SkynetBooking.Application.AiCustomers.Queries;

public record AiCustomerDto
{
    public int Id { get; init; }

    public string FullName { get; init; } = "";
}

public record ListAiCustomersQuery;

public class ListAiCustomersQueryHandler(ISkynetDbContext dbContext) : RequestHandler<ListAiCustomersQuery, List<AiCustomerDto>>
{
    public override async Task<AppResponse<List<AiCustomerDto>>> Handle(
        ListAiCustomersQuery request,
        CancellationToken cancellationToken)
    {
        var list = await dbContext.AiCustomers
            .OrderBy(c => c.Id)
            .Select(c => new AiCustomerDto { Id = c.Id, FullName = c.FullName })
            .ToListAsync(cancellationToken);

        return new(200, list);
    }
}
