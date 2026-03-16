namespace SkynetBooking.Core;

public class BookingEntity
{
    public int Id { get; set; }

    public int HumanResourceId { get; set; }
    public HumanResourceEntity HumanResource { get; set; } = null!;

    public int AiCustomerId { get; set; }
    public AiCustomerEntity AiCustomer { get; set; } = null!;

    public DateTime Start { get; set; }

    public DateTime End { get; set; }
}
