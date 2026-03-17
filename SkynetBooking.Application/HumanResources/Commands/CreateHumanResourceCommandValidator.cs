using FluentValidation;

namespace SkynetBooking.Application.HumanResources.Commands;

public class CreateHumanResourceCommandValidator : AbstractValidator<CreateHumanResourceCommand>
{
    public CreateHumanResourceCommandValidator()
    {
        RuleFor(x => x.MaxPayloadKg)
            .GreaterThanOrEqualTo(10)
            .WithMessage("MaxPayloadKg must be greater than or equal to 10.");
    }
}
