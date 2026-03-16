using FluentValidation.Results;
using Shouldly;

namespace SkynetBooking.WebApi.E2eTests.Shared.Extensions;

[ShouldlyMethods]
public static class ValidationResultExtensions
{
    private static string FormatErrorsString(List<ValidationFailure> errors)
    {
        return string.Join("\n", errors.Select(x => $"{x.PropertyName}: {x.ErrorMessage}"));
    }

    public static void ShouldHaveErrorForField(
        this ValidationResult target,
        string expectedPropertyName,
        string? expectedErrorMessage = null)
    {
        target.IsValid.ShouldBeFalse("Expected IsValid to be false but it was true.");

        var errorsString = FormatErrorsString(target.Errors);

        target.Errors.ShouldContain(x =>
            x.PropertyName == expectedPropertyName &&
            (expectedErrorMessage == null || x.ErrorMessage == expectedErrorMessage), $"Expected error message '{expectedErrorMessage}' but didn't find it. Found errors:\n {errorsString}");
    }

    public static void ShouldBeValid(
        this ValidationResult target)
    {
        var errorsString = FormatErrorsString(target.Errors);

        target.IsValid.ShouldBeTrue($"Expected IsValid to be true but it was false. Found errors:\n {errorsString}");
    }
}

