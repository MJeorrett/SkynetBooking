using SkynetBooking.Core;
using Microsoft.EntityFrameworkCore;

namespace SkynetBooking.Application.Common.Interfaces;

public interface ISkynetDbContext
{
    public DbSet<BookingEntity> Bookings { get; }

    public DbSet<HumanResourceEntity> HumanResources { get; }

    public DbSet<AiCustomerEntity> AiCustomers { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
