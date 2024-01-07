using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.Utility.Configurations;

internal sealed class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.ToTable("Districts", DataConstants.UtilitySchemaName);
        builder.HasKey(table => table.Id);
        builder.Property(table => table.CityId).IsRequired();
        builder.Property(model => model.Name).HasColumnType("varchar(100)").IsRequired();

        TrackableEntityConfiguration.Apply(builder);
    }
}