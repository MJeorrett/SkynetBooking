using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkynetBooking.Core;

namespace SkynetBooking.Infrastructure.Db.EntityTypeConfigurations;

public class BookingEntityTypeConfiguration : IEntityTypeConfiguration<BookingEntity>
{
    public void Configure(EntityTypeBuilder<BookingEntity> builder)
    {
        builder.ToTable("Bookings", builder =>
        {
            builder.HasCheckConstraint(
                "CK_Bookings_StartBeforeEnd",
                "[Start] < [End]");
        });
    }
}
