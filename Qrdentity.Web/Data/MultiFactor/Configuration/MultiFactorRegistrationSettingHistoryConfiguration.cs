using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.MultiFactor.Configuration;

internal sealed class
    MultiFactorRegistrationSettingHistoryConfiguration : IEntityTypeConfiguration<MultiFactorRegistrationSettingHistory>
{
    public void Configure(EntityTypeBuilder<MultiFactorRegistrationSettingHistory> builder)
    {
        builder.ToTable("MultiFactorRegistrationsHistory", DataConstants.PublicSchema);
        builder.HasKey(table => table.Id);

        builder.Property(mfr => mfr.UserId).IsRequired();
        builder.Property(mfr => mfr.UserProvidedCode).HasColumnType("char(6)").IsRequired().IsUnicode(false);

        TrackableEntityConfiguration.Apply(builder);
    }
}