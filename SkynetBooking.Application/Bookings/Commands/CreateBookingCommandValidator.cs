using FluentValidation;

namespace SkynetBooking.Application.Bookings.Commands;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidator()
    {
        RuleFor(x => x.End)
            .GreaterThan(x => x.Start)
            .WithMessage("Start must be before or equal to end.");
    }
}
