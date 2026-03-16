using SkynetBooking.Application.Common.Interfaces;
using SkynetBooking.Application.Common.AppRequests;
using SkynetBooking.Core;

namespace SkynetBooking.Application.Bookings.Commands;

public record CreateBookingCommand
{
    public int AiCustomerId { get; set; }

    public int HumanResourceId { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }
}

public class CreateBookingCommandHandler(ISkynetDbContext dbContext) : RequestHandler<CreateBookingCommand, int>
{
    public override async Task<AppResponse<int>> Handle(
        CreateBookingCommand command,
        CancellationToken cancellationToken)
    {
        var bookingEntity = new BookingEntity
        {
            AiCustomerId = command.AiCustomerId,
            HumanResourceId = command.HumanResourceId,
            Start = command.Start,
            End = command.End
        };

        dbContext.Bookings.Add(bookingEntity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new(201, bookingEntity.Id);
    }
}
