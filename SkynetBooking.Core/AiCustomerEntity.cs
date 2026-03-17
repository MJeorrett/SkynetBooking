namespace SkynetBooking.Core;

public class AiCustomerEntity : IEntityBase
{
    public int Id { get; set; }

    public required string FullName { get; set; }

    public required string SerialNumber { get; set; }
}
