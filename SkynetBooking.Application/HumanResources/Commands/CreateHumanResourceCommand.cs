using SkynetBooking.Application.Common.Interfaces;
using SkynetBooking.Application.Common.AppRequests;
using SkynetBooking.Core;

namespace SkynetBooking.Application.HumanResources.Commands;

public record CreateHumanResourceCommand
{
    public required string NonUniqueIdentifier { get; set; }

    public int MaxPayloadKg { get; set; }
}

public class CreateHumanResourceCommandHandler(ISkynetDbContext dbContext) : RequestHandler<CreateHumanResourceCommand, int>
{
    public override async Task<AppResponse<int>> Handle(
        CreateHumanResourceCommand command,
        CancellationToken cancellationToken)
    {
        var entity = new HumanResourceEntity
        {
            NonUniqueIdentifier = command.NonUniqueIdentifier,
            MaxPayloadKg = command.MaxPayloadKg
        };

        dbContext.HumanResources.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new(201, entity.Id);
    }
}
