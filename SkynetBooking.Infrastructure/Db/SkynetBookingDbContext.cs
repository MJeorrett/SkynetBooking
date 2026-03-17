using SkynetBooking.Application.Common.Interfaces;
using SkynetBooking.Core;
using Microsoft.EntityFrameworkCore;

namespace SkynetBooking.Infrastructure.Db;

public class SkynetDbContext : DbContext, ISkynetDbContext
{
    public DbSet<BookingEntity> Bookings { get; set; } = null!;

    public DbSet<AiCustomerEntity> AiCustomers { get; set; } = null!;

    public DbSet<HumanResourceEntity> HumanResources { get; set; } = null!;

    public SkynetDbContext(DbContextOptions<SkynetDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkynetDbContext).Assembly);
    }
}
