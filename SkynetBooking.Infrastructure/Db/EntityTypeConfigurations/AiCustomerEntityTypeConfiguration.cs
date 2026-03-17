using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkynetBooking.Core;

namespace SkynetBooking.Infrastructure.Db.EntityTypeConfigurations;

public class AiCustomerEntityTypeConfiguration : IEntityTypeConfiguration<AiCustomerEntity>
{
    public void Configure(EntityTypeBuilder<AiCustomerEntity> builder)
    {
        builder.ToTable("AiCustomers");
        
        builder.HasIndex(e => e.SerialNumber)
            .IsUnique();
    }
}
