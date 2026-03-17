namespace SkynetBooking.WebApi.E2eTests.Shared.TestData.Options;

public interface IEntityBuilderOptions<T>
{
    public T MapToEntity();
}
