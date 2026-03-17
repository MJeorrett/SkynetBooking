namespace SkynetBooking.WebApi.E2eTests.Shared.Dtos.HumanResources;

public record CreateHumanResourceRequestDto
{
    public string? NonUniqueIdentifier { get; set; }

    public int MaxPayloadKg { get; set; }
}
