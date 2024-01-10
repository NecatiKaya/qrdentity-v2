using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.MultiFactor.Configuration;

internal sealed class MultiFactorSettingConfiguration : IEntityTypeConfiguration<MultiFactorSetting>
{
    public void Configure(EntityTypeBuilder<MultiFactorSetting> builder)
    {
        builder.ToTable("MultiFactorSettings", DataConstants.ConfigurationSchema);
        builder.HasKey(table => table.Id);
        builder.Property(table => table.Id).IsUnicode(false).IsRequired().HasMaxLength(30).HasColumnType("varchar(30)");
        builder.Property(table => table.Descriptions).IsRequired().HasMaxLength(500).HasColumnType("varchar(500)")
            .IsUnicode();

        TrackableEntityConfiguration.Apply(builder);
    }
}