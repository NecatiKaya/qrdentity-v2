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

        builder.Property(table => table.Value).HasColumnType("varchar(100)").IsRequired().IsUnicode(false);
        builder.Property(table => table.MultiFactorSettingId)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnType("varchar(30)")
            .IsUnicode();
        
        builder.Property(table => table.CodeToAuthenticate)
            .IsRequired()
            .HasMaxLength(6)
            .HasColumnType("char(6)")
            .IsUnicode();

        builder.Property(table => table.MultiFactorRegistrationGroupId)
            .IsRequired();

        TrackableEntityConfiguration.Apply(builder);
    }
}