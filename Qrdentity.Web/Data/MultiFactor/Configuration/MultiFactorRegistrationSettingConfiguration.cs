using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.MultiFactor.Configuration;

internal sealed class
    MultiFactorRegistrationSettingConfiguration : IEntityTypeConfiguration<MultiFactorRegistrationSetting>
{
    public void Configure(EntityTypeBuilder<MultiFactorRegistrationSetting> builder)
    {
        builder.ToTable("MultiFactorRegistrationSettings", DataConstants.PublicSchema);
        builder.HasKey(table => table.Id);

        builder.Property(table => table.MultiFactorRegistrationId)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnType("varchar(30)")
            .IsUnicode();

        TrackableEntityConfiguration.Apply(builder);
    }
}