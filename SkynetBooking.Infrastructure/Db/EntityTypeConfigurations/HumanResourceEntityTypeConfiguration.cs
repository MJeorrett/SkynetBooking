using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkynetBooking.Core;

namespace SkynetBooking.Infrastructure.Db.EntityTypeConfigurations;

public class HumanResourceEntityTypeConfiguration : IEntityTypeConfiguration<HumanResourceEntity>
{
    public void Configure(EntityTypeBuilder<HumanResourceEntity> builder)
    {
        builder.ToTable("HumanResources");
    }
}
