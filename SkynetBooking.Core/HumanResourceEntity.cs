namespace SkynetBooking.Core;

public class HumanResourceEntity : IEntityBase
{
    public int Id { get; set; }

    // AKA "Full Name"
    public required string NonUniqueIdentifier { get; set; }

    public int MaxPayloadKg { get; set; }
}
