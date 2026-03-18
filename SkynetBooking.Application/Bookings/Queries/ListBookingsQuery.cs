using Microsoft.EntityFrameworkCore;
using SkynetBooking.Application.Common.AppRequests;
using SkynetBooking.Application.Common.Interfaces;

namespace SkynetBooking.Application.Bookings.Queries;

public record BookingSummaryDto
{
    public int Id { get; init; }

    public int AiCustomerId { get; init; }

    public int HumanResourceId { get; init; }

    public DateTime Start { get; init; }

    public DateTime End { get; init; }
}

public record ListBookingsQuery;

public class ListBookingsQueryHandler(ISkynetDbContext dbContext) : RequestHandler<ListBookingsQuery, List<BookingSummaryDto>>
{
    public override async Task<AppResponse<List<BookingSummaryDto>>> Handle(
        ListBookingsQuery request,
        CancellationToken cancellationToken)
    {
        var list = await dbContext.Bookings
            .OrderBy(b => b.Id)
            .Select(b => new BookingSummaryDto
            {
                Id = b.Id,
                AiCustomerId = b.AiCustomerId,
                HumanResourceId = b.HumanResourceId,
                Start = b.Start,
                End = b.End,
            })
            .ToListAsync(cancellationToken);

        return new(200, list);
    }
}

