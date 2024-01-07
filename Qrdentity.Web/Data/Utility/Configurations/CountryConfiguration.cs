using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.Utility.Configurations;

internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries", DataConstants.UtilitySchemaName);
        builder.HasKey(table => table.Id);

        builder
            .HasMany(country => country.Cities)
            .WithOne(city => city.Country)
            .HasForeignKey(city => city.CountryId)
            .IsRequired();

        builder.HasIndex(model => model.Name, "Unique_Index_Name").IsUnique();
        builder.Property(model => model.Name).HasColumnType("varchar(100)").IsRequired();

        TrackableEntityConfiguration.Apply(builder);
    }
}