using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.Utility.Configurations;

internal sealed class TaxOfficeConfiguration : IEntityTypeConfiguration<TaxOffice>
{
    public void Configure(EntityTypeBuilder<TaxOffice> builder)
    {
        builder.ToTable("TaxOffices", DataConstants.UtilitySchemaName);
        builder.HasKey(table => table.Id);
        builder.Property(model => model.DistrictId).IsRequired();
        builder.Property(model => model.OfficeName).IsRequired().HasColumnType("varchar(100)");
        builder.Property(model => model.SortOrder).IsRequired();
        builder.Property(model => model.PlateNumber).IsRequired().HasColumnType("varchar(2)");

        TrackableEntityConfiguration.Apply(builder);
    }
}