using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.B2B.Configurations;

internal sealed class BusinessSubTypeConfiguration : IEntityTypeConfiguration<BusinessSubType>
{
    public void Configure(EntityTypeBuilder<BusinessSubType> builder)
    {
        builder.ToTable("BusinessSubTypes", DataConstants.B2BSchemaName);
        builder.HasKey(table => table.Id);
        builder.HasIndex(model => model.Name, "Unique_Index_Name").IsUnique();
        builder.Property(model => model.Name).HasColumnType("varchar(100)").IsRequired();
        builder.Property(model => model.Descriptions).HasColumnType("json").IsRequired();

        TrackableEntityConfiguration.Apply(builder);
    }
}