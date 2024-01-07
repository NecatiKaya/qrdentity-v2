using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.B2B.Configurations;

internal sealed class OrganizationAddressConfiguration : IEntityTypeConfiguration<OrganizationAddress>
{
    public void Configure(EntityTypeBuilder<OrganizationAddress> builder)
    {
        builder.ToTable("OrganizationAddresses", DataConstants.B2BSchemaName);
        builder.HasKey(table => table.Id);
        builder.Property(model => model.OrganizationId).IsRequired();
        builder.Property(model => model.DistrictId).IsRequired();
        builder.Property(model => model.Address).HasColumnType("varchar(250)").IsRequired();
        builder.Property(model => model.ZipCode).HasColumnType("varchar(10)").IsRequired();
        builder.Property(model => model.GoogleMapsLink).HasColumnType("varchar(500)");

        TrackableEntityConfiguration.Apply(builder);
    }
}