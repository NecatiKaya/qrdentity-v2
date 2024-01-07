using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.Utility.Configurations;

internal sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities", DataConstants.UtilitySchemaName);
        builder.HasKey(table => table.Id);
        builder
            .HasMany(country => country.Districts)
            .WithOne(district => district.City)
            .HasForeignKey(district => district.CityId)
            .IsRequired();
        builder.HasIndex(model => model.Name, "Unique_Index_Name").IsUnique();
        builder.Property(model => model.Name).HasColumnType("varchar(100)").IsRequired();

        TrackableEntityConfiguration.Apply(builder);
    }
}