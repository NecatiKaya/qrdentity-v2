using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;

namespace Qrdentity.Web.Data.Common.Configurations;

public sealed class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.ToTable("UserAddresses", DataConstants.PublicSchema);
        builder.HasKey(table => table.Id);
        
        builder.Property(model => model.DistrictId).IsRequired();
        builder.Property(model => model.Address).HasColumnType("varchar(250)").IsRequired().IsUnicode();
        builder.Property(model => model.ZipCode).HasColumnType("varchar(10)").IsRequired().IsUnicode(false);
        builder.Property(model => model.GoogleMapsLink).HasColumnType("varchar(500)");
        
        TrackableEntityConfiguration.Apply(builder);
    }
}