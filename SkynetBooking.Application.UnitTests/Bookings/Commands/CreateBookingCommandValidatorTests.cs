using SkynetBooking.Application.Bookings.Commands;
using Shouldly;

namespace SkynetBooking.Application.UnitTests.Bookings.Commands;

public class CreateBookingCommandValidatorTests
{
    [Fact]
    public void Should_Fail_When_EndBeforeStart()
    {
        var validator = new CreateBookingCommandValidator();
        var start = new DateTime(2025, 3, 16, 10, 0, 0);
        var command = new CreateBookingCommand
        {
            AiCustomerId = 1,
            HumanResourceId = 1,
            Start = start,
            End = start.AddHours(-1) // End before Start
        };

        var result = validator.Validate(command);

        result.IsValid.ShouldBeFalse();
    }
}
