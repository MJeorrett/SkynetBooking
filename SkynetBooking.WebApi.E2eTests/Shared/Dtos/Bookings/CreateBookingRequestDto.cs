namespace SkynetBooking.WebApi.E2eTests.Shared.Dtos.Bookings;

public record CreateBookingRequestDto
{
    public int? AiCustomerId { get; set; }
    public int? HumanResourceId { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
}